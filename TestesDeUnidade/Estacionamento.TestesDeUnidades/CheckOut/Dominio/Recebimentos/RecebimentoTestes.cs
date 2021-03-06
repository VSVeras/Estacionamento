﻿using CheckOut.Dominio.Recebimentos;
using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Fabricas;
using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Infraestrutura.SistemaOperacional;
using Nucleo.Compartilhado.Dominio;
using Nucleo.Compartilhado.Dominio.Condutores;
using Nucleo.Compartilhado.Dominio.Veiculos;
using Nucleo.Compartilhado.Infraestrutura.SistemaOperacional;
using System;
using Xunit;

namespace Estacionamento.TestesDeUnidades.CheckOut.Dominio.Recebimentos
{
    public partial class RecebimentoTestes
    {
        private readonly IProvedorDoTempo _provedorDoTempo;
        private readonly Recebimento _recebimento;
        private readonly Veiculo _veiculo;
        private readonly Bilhete _bilhete;
        private readonly decimal _valorDaTransacao = 10m;
        private readonly int _ticketId = 1;
        private readonly int _minutosEmUmaHora = 60;
        private readonly Ticket _ticket;

        public RecebimentoTestes()
        {
            _provedorDoTempo = new ProvedorDataHoraSistema();
            _recebimento = new Recebimento();
            _veiculo = new FabricaDeVeiculo().ComAPlacaPadrao().Criar();
            _bilhete = new Bilhete(_ticketId, DateTime.UtcNow, _veiculo);
            _ticket = new Ticket(_bilhete.TicketId, _bilhete.DataHoraDeEntrada, _bilhete.Veiculo);
        }

        [Fact]
        public void Deve_conferir_um_ticket_emitido_ha_quinze_minutos()
        {
            //arrange
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = DateTime.UtcNow.AddMinutes(15) };
            _ticket.Saida(dataHoraDaSaida);

            //act
            _recebimento.Conferir(_ticket);

            //assert
            Assert.Equal(_bilhete.DataHoraDeEntrada, _recebimento.Ticket.Permanencia.Entrada);
            Assert.Equal(dataHoraDaSaida.DataHora, _recebimento.Ticket.Permanencia.Saida);
        }

        [Fact]
        public void Deve_realizar_uma_cobranca_pela_permanencia_de_um_dia()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = _bilhete.DataHoraDeEntrada.AddDays(1) };
            _ticket.Saida(dataHoraDaSaida);
            _recebimento.Conferir(_ticket);
            var cobrancaPorHora = new CobrancaPorDiaria();

            _recebimento.CobrancaPorPermanencia(cobrancaPorHora);

            decimal valorDaDiaria = 22.00m;
            double permanenciaEmHoras = 24;
            double totalDaPermanencia = ArredondarParaBaixo((double)valorDaDiaria / permanenciaEmHoras, 1);
            decimal valorEsperadoDoTotalAPagar = valorDaDiaria * (decimal)totalDaPermanencia;
            Assert.Equal(valorEsperadoDoTotalAPagar, _recebimento.TotalAPagar);
        }

        [Fact]
        public void Deve_realizar_uma_cobranca_pela_permanencia_de_quarenta_e_cinco_minutos()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = _bilhete.DataHoraDeEntrada.AddMinutes(45) };
            _ticket.Saida(dataHoraDaSaida);
            _recebimento.Conferir(_ticket);
            var cobrancaPorHora = new CobrancaPorHora();

            _recebimento.CobrancaPorPermanencia(cobrancaPorHora);

            decimal valorDaHora = 12.00m;
            double totalDaPermanenciaEmMinutos = 45;
            decimal valorEsperadoDoTotalAPagar = valorDaHora * (decimal)(totalDaPermanenciaEmMinutos / _minutosEmUmaHora);
            Assert.Equal(valorEsperadoDoTotalAPagar, _recebimento.TotalAPagar);
        }

        [Fact]
        public void Deve_realizar_uma_cobranca_pela_permanencia_de_uma_hora()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = _bilhete.DataHoraDeEntrada.AddHours(1) };
            _ticket.Saida(dataHoraDaSaida);
            _recebimento.Conferir(_ticket);
            var cobrancaPorHora = new CobrancaPorHora();

            _recebimento.CobrancaPorPermanencia(cobrancaPorHora);

            decimal valorDaHora = 12.00m;
            double totalDaPermanenciaEmMinutos = 60;
            decimal valorEsperadoDoTotalAPagar = valorDaHora * (decimal)(totalDaPermanenciaEmMinutos / _minutosEmUmaHora);
            Assert.Equal(valorEsperadoDoTotalAPagar, _recebimento.TotalAPagar);
        }

        [Fact]
        public void Deve_registrar_uma_forma_de_pagamento_a_um_recebimento()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = _bilhete.DataHoraDeEntrada.AddMinutes(15) };
            _ticket.Saida(dataHoraDaSaida);
            _recebimento.Conferir(_ticket);
            var cobrancaPorHora = new CobrancaPorDiaria();
            _recebimento.CobrancaPorPermanencia(cobrancaPorHora);
            var transacaoEmDinheiro = new TransacaoFinanceira(FormaDePagamento.Dinheiro, _valorDaTransacao);

            _recebimento.Registrar(transacaoEmDinheiro);

            var transacoesFinanceirasEsperada = new TransacoesFinanceiras();
            transacoesFinanceirasEsperada.Adicionar(new TransacaoFinanceira(FormaDePagamento.Dinheiro, _valorDaTransacao));
            Assert.Equal(transacoesFinanceirasEsperada.Transacoes, _recebimento.TransacoesFinanceiras.Transacoes);
            Assert.True(_recebimento.TotalDasTransacoesFinanceiras() == _valorDaTransacao);
        }

        [Fact]
        public void Deve_registrar_duas_forma_de_pagamento_a_um_recebimento()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = _bilhete.DataHoraDeEntrada.AddMinutes(15) };
            _ticket.Saida(dataHoraDaSaida);
            _recebimento.Conferir(_ticket);
            var cobrancaPorHora = new CobrancaPorDiaria();
            _recebimento.CobrancaPorPermanencia(cobrancaPorHora);
            var transacaoEmDinheiro = new TransacaoFinanceira(FormaDePagamento.Dinheiro, _valorDaTransacao);
            _recebimento.Registrar(transacaoEmDinheiro);
            var transacaoEmCartaDeDebito = new TransacaoFinanceira(FormaDePagamento.CartaoDeDebito, _valorDaTransacao);

            _recebimento.Registrar(transacaoEmCartaDeDebito);

            var valorDaTransacaoEsperado = _valorDaTransacao * 2;
            var transacoesFinanceirasEsperada = new TransacoesFinanceiras();
            transacoesFinanceirasEsperada.Adicionar(new TransacaoFinanceira(FormaDePagamento.Dinheiro, _valorDaTransacao));
            transacoesFinanceirasEsperada.Adicionar(new TransacaoFinanceira(FormaDePagamento.CartaoDeDebito, _valorDaTransacao));
            Assert.Equal(transacoesFinanceirasEsperada.Transacoes, _recebimento.TransacoesFinanceiras.Transacoes);
            Assert.True(_recebimento.TotalDasTransacoesFinanceiras() == valorDaTransacaoEsperado);
        }

        public double ArredondarParaBaixo(double valor, int numeroDeCasasDecimais)
        {
            var valorParaArredondamento = Math.Pow(10, numeroDeCasasDecimais);
            return Math.Ceiling(valor * valorParaArredondamento) / valorParaArredondamento;
        }
    }
}

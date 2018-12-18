using System;
using Xunit;
using CheckOut.Dominio.Recebimentos;
using Nucleo.Compartilhado.Dominio;
using Nucleo.Compartilhado.Infraestrutura.SistemaOperacional;
using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Fabricas;
using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Infraestrutura.SistemaOperacional;
using Nucleo.Compartilhado.Dominio.Condutores;
using Nucleo.Compartilhado.Dominio.Veiculos;

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

        public RecebimentoTestes()
        {
            _provedorDoTempo = new ProvedorDataHoraSistema();
            _recebimento = new Recebimento();
            _veiculo = new FabricaDeVeiculo().ComAPlacaPadrao().Criar();
            _bilhete = new Bilhete(_ticketId, DateTime.UtcNow, _veiculo);
        }

        [Fact]
        public void Deve_conferir_um_ticket_emitido_ha_quinze_minutos()
        {
            //arrange
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = DateTime.UtcNow.AddMinutes(15) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);

            //act
            _recebimento.Conferir(ticket);

            //assert
            Assert.Equal(_bilhete.TicketId, _recebimento.Ticket.Id);
            Assert.Equal(_bilhete.Veiculo, _recebimento.Ticket.Veiculo);
            Assert.Equal(_bilhete.DataHoraDeEntrada, _recebimento.Ticket.Permanencia.Entrada);
            Assert.Equal(dataHoraDaSaida.DataHora, _recebimento.Ticket.Permanencia.Saida);
        }

        [Fact]
        public void Deve_realizar_uma_cobranca_pela_permanencia_de_um_dia()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = _bilhete.DataHoraDeEntrada.AddDays(1) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);
            _recebimento.Conferir(ticket);
            var cobrancaPorHora = new CobrancaPorDiaria();

            _recebimento.CobrancaPorPermanencia(cobrancaPorHora);

            decimal valorDaDiaria = 22.00m;
            double permanenciaEmHoras = 24;
            double totalDaPermanencia = ArredondarParaBaixo((double) valorDaDiaria / permanenciaEmHoras, 1);
            decimal valorEsperadoDoTotalAPagar = valorDaDiaria * (decimal) totalDaPermanencia;
            Assert.Equal(valorEsperadoDoTotalAPagar, _recebimento.TotalAPagar);
        }

        [Fact]
        public void Deve_realizar_uma_cobranca_pela_permanencia_de_quarenta_e_cinco_minutos()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = _bilhete.DataHoraDeEntrada.AddMinutes(45) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);
            _recebimento.Conferir(ticket);
            var cobrancaPorHora = new CobrancaPorHora();

            _recebimento.CobrancaPorPermanencia(cobrancaPorHora);

            decimal valorDaHora = 12.00m;
            double totalDaPermanenciaEmMinutos = 45;
            decimal valorEsperadoDoTotalAPagar = valorDaHora * (decimal) (totalDaPermanenciaEmMinutos / _minutosEmUmaHora);
            Assert.Equal(valorEsperadoDoTotalAPagar, _recebimento.TotalAPagar);
        }

        [Fact]
        public void Deve_realizar_uma_cobranca_pela_permanencia_de_uma_hora()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = _bilhete.DataHoraDeEntrada.AddHours(1) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);
            _recebimento.Conferir(ticket);
            var cobrancaPorHora = new CobrancaPorHora();

            _recebimento.CobrancaPorPermanencia(cobrancaPorHora);

            decimal valorDaHora = 12.00m;
            double totalDaPermanenciaEmMinutos = 60;
            decimal valorEsperadoDoTotalAPagar = valorDaHora * (decimal) (totalDaPermanenciaEmMinutos / _minutosEmUmaHora);
            Assert.Equal(valorEsperadoDoTotalAPagar, _recebimento.TotalAPagar);
        }

        [Fact]
        public void Deve_registrar_uma_forma_de_pagamento_a_um_recebimento()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = _bilhete.DataHoraDeEntrada.AddMinutes(15) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);
            _recebimento.Conferir(ticket);
            var cobrancaPorHora = new CobrancaPorDiaria();
            _recebimento.CobrancaPorPermanencia(cobrancaPorHora);
            var transacaoEmDinheiro = new TransacaoFinanceira(FormaDePagamento.Dinheiro, _valorDaTransacao);

            _recebimento.Registrar(transacaoEmDinheiro);

            var transacoesFinanceirasEsperada = new TransacoesFinanceiras();
            transacoesFinanceirasEsperada.Adicionar(new TransacaoFinanceira(FormaDePagamento.Dinheiro, _valorDaTransacao));
            Assert.Equal(transacoesFinanceirasEsperada.Todas(), _recebimento.TransacoesFinanceiras);
            Assert.True(_recebimento.TotalDasTransacoesFinanceiras() == _valorDaTransacao);
        }

        [Fact]
        public void Deve_registrar_duas_forma_de_pagamento_a_um_recebimento()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = _bilhete.DataHoraDeEntrada.AddMinutes(15) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);
            _recebimento.Conferir(ticket);
            var cobrancaPorHora = new CobrancaPorDiaria();
            _recebimento.CobrancaPorPermanencia(cobrancaPorHora);
            var transacaoEmDinheiro = new TransacaoFinanceira(FormaDePagamento.Dinheiro, _valorDaTransacao);
            var transacaoEmCartaDeDebito = new TransacaoFinanceira(FormaDePagamento.CartaoDeDebito, _valorDaTransacao);
            _recebimento.Registrar(transacaoEmDinheiro);

            _recebimento.Registrar(transacaoEmCartaDeDebito);

            var valorDaTransacaoEsperado = _valorDaTransacao * 2;
            var transacoesFinanceirasEsperada = new TransacoesFinanceiras();
            transacoesFinanceirasEsperada.Adicionar(new TransacaoFinanceira(FormaDePagamento.Dinheiro, _valorDaTransacao));
            transacoesFinanceirasEsperada.Adicionar(new TransacaoFinanceira(FormaDePagamento.CartaoDeDebito, _valorDaTransacao));
            Assert.Equal(transacoesFinanceirasEsperada.Todas(), _recebimento.TransacoesFinanceiras);
            Assert.True(_recebimento.TotalDasTransacoesFinanceiras() == valorDaTransacaoEsperado);
        }

        public Ticket CriaUmTicket()
        {
            return new Ticket(_bilhete.TicketId, _bilhete.DataHoraDeEntrada, _bilhete.Veiculo);
        }

        public double ArredondarParaBaixo(double valor, int numeroDeCasasDecimais)
        {
            return Math.Ceiling(valor * Math.Pow(10, numeroDeCasasDecimais)) / Math.Pow(10, numeroDeCasasDecimais);
        }
    }
}

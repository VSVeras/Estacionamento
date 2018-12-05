using System;
using Xunit;
using CheckOut.Dominio.Recebimentos;
using Nucleo.Compartilhado.Dominio;
using Nucleo.Compartilhado.Infraestrutura.SistemaOperacional;
using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Fabricas;
using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Infraestrutura.SistemaOperacional;
using Nucleo.Compartilhado.Dominio.Condutores;

namespace Estacionamento.TestesDeUnidades.CheckOut.Dominio.Recebimentos
{
    public partial class RecebimentoTestes
    {
        private readonly IProvedorDoTempo provedorDoTempo;
        private readonly Recebimento recebimento;
        private readonly Veiculo veiculo;
        private readonly Bilhete bilhete;
        private readonly decimal valorDaTransacao = 10m;
        private readonly int ticketId = 1;
        private readonly int minutosEmUmaHora = 60;

        public RecebimentoTestes()
        {
            provedorDoTempo = new ProvedorDataHoraSistema();
            recebimento = new Recebimento();
            veiculo = new FabricaDeVeiculo().ComAPlacaPadrao().Criar();
            bilhete = new Bilhete(ticketId, DateTime.UtcNow, veiculo);
        }

        [Fact]
        public void Deve_conferir_um_ticket_emitido_ha_quinze_minutos()
        {
            //arrange
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = DateTime.UtcNow.AddMinutes(15) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);

            //act
            recebimento.Conferir(ticket);

            //assert
            Assert.Equal(bilhete.TicketId, recebimento.Ticket.Id);
            Assert.Equal(bilhete.Veiculo, recebimento.Ticket.Veiculo);
            Assert.Equal(bilhete.DataHoraDeEntrada, recebimento.Ticket.Permanencia.Entrada);
            Assert.Equal(dataHoraDaSaida.DataHora, recebimento.Ticket.Permanencia.Saida);
        }

        [Fact]
        public void Deve_realizar_uma_cobranca_pela_permanencia_de_um_dia()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = bilhete.DataHoraDeEntrada.AddDays(1) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);
            recebimento.Conferir(ticket);
            var cobrancaPorHora = new CobrancaPorDiaria();

            recebimento.CobrancaPorPermanencia(cobrancaPorHora);

            decimal valorDaDiaria = 22.00m;
            double permanenciaEmHoras = 24;
            double totalDaPermanencia = ArredondarParaBaixo((double) valorDaDiaria / permanenciaEmHoras, 1);
            decimal valorEsperadoDoTotalAPagar = valorDaDiaria * (decimal) totalDaPermanencia;
            Assert.Equal(valorEsperadoDoTotalAPagar, recebimento.TotalAPagar);
        }

        [Fact]
        public void Deve_realizar_uma_cobranca_pela_permanencia_de_quarenta_e_cinco_minutos()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = bilhete.DataHoraDeEntrada.AddMinutes(45) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);
            recebimento.Conferir(ticket);
            var cobrancaPorHora = new CobrancaPorHora();

            recebimento.CobrancaPorPermanencia(cobrancaPorHora);

            decimal valorDaHora = 12.00m;
            double totalDaPermanenciaEmMinutos = 45;
            decimal valorEsperadoDoTotalAPagar = valorDaHora * (decimal) (totalDaPermanenciaEmMinutos / minutosEmUmaHora);
            Assert.Equal(valorEsperadoDoTotalAPagar, recebimento.TotalAPagar);
        }

        [Fact]
        public void Deve_realizar_uma_cobranca_pela_permanencia_de_uma_hora()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = bilhete.DataHoraDeEntrada.AddHours(1) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);
            recebimento.Conferir(ticket);
            var cobrancaPorHora = new CobrancaPorHora();

            recebimento.CobrancaPorPermanencia(cobrancaPorHora);

            decimal valorDaHora = 12.00m;
            double totalDaPermanenciaEmMinutos = 60;
            decimal valorEsperadoDoTotalAPagar = valorDaHora * (decimal) (totalDaPermanenciaEmMinutos / minutosEmUmaHora);
            Assert.Equal(valorEsperadoDoTotalAPagar, recebimento.TotalAPagar);
        }

        [Fact]
        public void Deve_registrar_uma_forma_de_pagamento_a_um_recebimento()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = bilhete.DataHoraDeEntrada.AddMinutes(15) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);
            recebimento.Conferir(ticket);
            var cobrancaPorHora = new CobrancaPorDiaria();
            recebimento.CobrancaPorPermanencia(cobrancaPorHora);
            var transacaoEmDinheiro = new TransacaoFinanceira(FormaDePagamento.Dinheiro, valorDaTransacao);

            recebimento.Registrar(transacaoEmDinheiro);

            var transacoesFinanceirasEsperada = new TransacoesFinanceiras();
            transacoesFinanceirasEsperada.Adicionar(new TransacaoFinanceira(FormaDePagamento.Dinheiro, valorDaTransacao));
            Assert.Equal(transacoesFinanceirasEsperada.Todas(), recebimento.TransacoesFinanceiras);
            Assert.True(recebimento.TotalDasTransacoesFinanceiras() == valorDaTransacao);
        }

        [Fact]
        public void Deve_registrar_duas_forma_de_pagamento_a_um_recebimento()
        {
            var dataHoraDaSaida = new SimuladorDeDataHoraDoSistema { DataHora = bilhete.DataHoraDeEntrada.AddMinutes(15) };
            var ticket = CriaUmTicket();
            ticket.Saida(dataHoraDaSaida);
            recebimento.Conferir(ticket);
            var cobrancaPorHora = new CobrancaPorDiaria();
            recebimento.CobrancaPorPermanencia(cobrancaPorHora);
            var transacaoEmDinheiro = new TransacaoFinanceira(FormaDePagamento.Dinheiro, valorDaTransacao);
            var transacaoEmCartaDeDebito = new TransacaoFinanceira(FormaDePagamento.CartaoDeDebito, valorDaTransacao);
            recebimento.Registrar(transacaoEmDinheiro);

            recebimento.Registrar(transacaoEmCartaDeDebito);

            var valorDaTransacaoEsperado = valorDaTransacao * 2;
            var transacoesFinanceirasEsperada = new TransacoesFinanceiras();
            transacoesFinanceirasEsperada.Adicionar(new TransacaoFinanceira(FormaDePagamento.Dinheiro, valorDaTransacao));
            transacoesFinanceirasEsperada.Adicionar(new TransacaoFinanceira(FormaDePagamento.CartaoDeDebito, valorDaTransacao));
            Assert.Equal(transacoesFinanceirasEsperada.Todas(), recebimento.TransacoesFinanceiras);
            Assert.True(recebimento.TotalDasTransacoesFinanceiras() == valorDaTransacaoEsperado);
        }

        public Ticket CriaUmTicket()
        {
            return new Ticket(bilhete.TicketId, bilhete.DataHoraDeEntrada, bilhete.Veiculo);
        }

        public double ArredondarParaBaixo(double valor, int numeroDeCasasDecimais)
        {
            return Math.Ceiling(valor * Math.Pow(10, numeroDeCasasDecimais)) / Math.Pow(10, numeroDeCasasDecimais);
        }
    }
}

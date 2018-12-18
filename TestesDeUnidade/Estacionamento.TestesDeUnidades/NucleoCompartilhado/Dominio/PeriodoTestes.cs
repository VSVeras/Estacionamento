using CheckOut.Dominio.Recebimentos;
using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Infraestrutura.SistemaOperacional;
using System;
using Xunit;

namespace Estacionamento.TestesDeUnidades.NucleoCompartilhado.Dominio
{
    public class PeriodoTestes
    {
        private DateTime dataHoraAgoraMenos15Minutos;
        private DateTime dataHoraAgora;

        public PeriodoTestes()
        {
            dataHoraAgora = new DateTime();
        }

        [Fact]
        public void Deve_comparar_periodos_iguais()
        {
            dataHoraAgoraMenos15Minutos = DateTime.UtcNow.AddMinutes(-15);
            var periodo = new Periodo(dataHoraAgoraMenos15Minutos, new SimuladorDeDataHoraDoSistema { DataHora = dataHoraAgora });
            var outroPeriodo = new Periodo(dataHoraAgoraMenos15Minutos, new SimuladorDeDataHoraDoSistema { DataHora = dataHoraAgora });

            Assert.Equal(periodo, outroPeriodo);
        }

        [Fact]
        public void Deve_comparar_periodos_diferentes()
        {
            dataHoraAgoraMenos15Minutos = DateTime.UtcNow.AddMinutes(-15);
            var periodo = new Periodo(dataHoraAgoraMenos15Minutos, new SimuladorDeDataHoraDoSistema { DataHora = dataHoraAgora });
            var periodoDiferente = new Periodo(dataHoraAgoraMenos15Minutos, new SimuladorDeDataHoraDoSistema { DataHora = new DateTime(2018, 09, 10, 6, 30, 0) });

            Assert.NotEqual(periodo, periodoDiferente);
        }

        [Fact]
        public void Deve_comparar_dois_periodos_iguais()
        {
            var dataFinal = new SimuladorDeDataHoraDoSistema { DataHora = dataHoraAgora.AddMinutes(15) };
            var periodoUm = new Periodo(dataHoraAgora, dataFinal);
            var periodoDois = new Periodo(dataHoraAgora, dataFinal);

            Assert.Equal(periodoUm, periodoDois);
        }
    }
}

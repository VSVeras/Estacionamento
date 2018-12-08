using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Fabricas;
using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Infraestrutura.SistemaOperacional;
using Estacionamento.TestesDeUnidades.Patio.Infraestrutura;
using Nucleo.Compartilhado.Dominio;
using Nucleo.Compartilhado.Dominio.Condutores;
using Nucleo.Compartilhado.Dominio.Veiculos;
using Patio.Aplicacao.CasosDeUso.Condutores;
using Patio.Dominio.Tickets;
using System;
using Xunit;

namespace Estacionamento.TestesDeUnidades.Patio.Aplicacao.CasosDeUso.Condutores
{
    public class ServicoDeCondutorTestes
    {
        private readonly IProvedorDoTempo _provedorDoTempo;
        private readonly Veiculo _veiculo;
        private readonly IRepositorioDeLeituraTickets _repositorioDeLeituraTickets;

        public ServicoDeCondutorTestes()
        {
            _provedorDoTempo = new SimuladorDeDataHoraDoSistema { DataHora = DateTime.UtcNow };
            _veiculo = new FabricaDeVeiculo().ComAPlacaPadrao().Criar();
            //TODO Depois trocar pela implementação real do repositório
            _repositorioDeLeituraTickets = new SimuladorDeRepositorioDeLeituraDeTickets(_provedorDoTempo, _veiculo);
        }

        [Fact]
        public void Deve_obter_um_bilhete_emitido()
        {
            //arrange
            IServicoDeCondutor servicoDeCondutor = new ServicoDeCondutor(_repositorioDeLeituraTickets);

            //act
            var bilhete = servicoDeCondutor.ObterBilheteEmitidoPor(0);

            //assert
            var bilheteEsperado = new Bilhete(0, _provedorDoTempo.DataHora, _veiculo);
            Assert.Equal(bilheteEsperado, bilhete);
        }
    }
}

using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Fabricas;
using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Infraestrutura.SistemaOperacional;
using Nucleo.Compartilhado.Comum.Dominio;
using Nucleo.Compartilhado.Infraestrutura.SistemaOperacional;
using Patio.Dominio.Condutores;
using Patio.Dominio.Tickets;
using Xunit;

namespace Estacionamento.TestesDeUnidades.Patio.Dominio.Tickets
{
    public class TicketTestes
    {
        [Fact]
        public void Deve_criar_um_ticket_para_o_estacionamento_de_um_veiculo()
        {
            //arrange
            var placaPadrao = "NHC 3030";
            IServicoDeEstacionamento servicoDeEstacionamento = new Condutor();
            var veiculo = servicoDeEstacionamento.Estacionar(placaPadrao);
            IProvedorDoTempo provedorDoTempo = new ProvedorDataHoraSistema();
            var ticket = new Ticket(provedorDoTempo);

            //act
            ticket.Entrada(veiculo);

            //assert
            var veiculoEsperado = new FabricaDeVeiculo().ComAPlacaPadrao().Criar();
            var dataHoraEspedada = new SimuladorDeDataHoraDoSistema { DataHora = ticket.DataHoraDeEntrada };
            Assert.Equal(veiculoEsperado, ticket.Veiculo);
            Assert.Equal(dataHoraEspedada.DataHora, ticket.DataHoraDeEntrada);
        }
    }
}

using Nucleo.Compartilhado.Comum.Dominio;
using Nucleo.Compartilhado.Infraestrutura.SistemaOperacional;
using Patio.Dominio.Atendentes;
using Patio.Dominio.Condutores;
using Xunit;

namespace Estacionamento.TestesDeUnidades.Patio.Dominio.Atendentes
{
    public class AtendenteTestes
    {
        [Fact]
        public void Deve_registrar_a_entrada_de_um_veiculo()
        {
            //arrange
            var placaPadrao = "NHC 3030";
            IServicoDeEstacionamento servicoDeEstacionamento = new Condutor();
            IProvedorDoTempo provedorDoTempo = new ProvedorDataHoraSistema();

            //act
            var ticket = Atendente.Registrar.Entrada(provedorDoTempo, servicoDeEstacionamento, placaPadrao);

            //assert
            Assert.NotNull(ticket);
        }
    }
}

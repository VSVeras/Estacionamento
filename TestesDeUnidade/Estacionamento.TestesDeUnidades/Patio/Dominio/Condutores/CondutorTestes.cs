using Xunit;
using Patio.Dominio.Condutores;
using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Fabricas;

namespace Estacionamento.TestesDeUnidades.Patio.Dominio.Condutores
{
    public class CondutorTestes
    {
        [Fact]
        public void Deve_estacionar_um_veiculo_na_area_do_patio()
        {
            //arrange
            var placaPadrao = "NHC 3030";
            IServicoDeEstacionamento servicoDeEstacionamento = new Condutor();

            //act
            var veiculo = servicoDeEstacionamento.Estacionar(placaPadrao);

            //assert
            var veiculoEsperado = new FabricaDeVeiculo().ComAPlacaPadrao().Criar();
            Assert.Equal(veiculoEsperado, veiculo);
        }
    }
}

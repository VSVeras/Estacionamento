using Nucleo.Compartilhado.Dominio.Condutores;
using Nucleo.Compartilhado.Dominio.Veiculos;

namespace Estacionamento.TestesDeUnidades.NucleoCompartilhado.Fabricas
{
    public sealed class FabricaDeVeiculo
    {
        private Placa Placa;

        public FabricaDeVeiculo ComAPlacaPadrao()
        {
            Placa = new Placa("NHC 3030");
            return this;
        }

        public FabricaDeVeiculo ComAPlaca(string placa)
        {
            Placa = new Placa(placa);
            return this;
        }

        public Veiculo Criar()
        {
            return new Veiculo(Placa);
        }
    }
}

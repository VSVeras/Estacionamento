using Nucleo.Compartilhado.Dominio;

namespace Estacionamento.TestesDeUnidades.NucleoCompartilhado.Fabricas
{
    public sealed class FabricaDeVeiculo
    {
        private string Placa;

        public FabricaDeVeiculo ComAPlacaPadrao()
        {
            Placa = "NHC 3030";
            return this;
        }

        public FabricaDeVeiculo ComAPlaca(string placa)
        {
            Placa = placa;
            return this;
        }

        public Veiculo Criar()
        {
            return new Veiculo(Placa);
        }
    }
}

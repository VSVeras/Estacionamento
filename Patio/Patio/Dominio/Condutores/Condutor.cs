using Nucleo.Compartilhado.Dominio;

namespace Patio.Dominio.Condutores
{
    public sealed class Condutor : IServicoDeEstacionamento
    {
        public Veiculo Estacionar(string placa)
        {
            return new Veiculo(placa);
        }
    }
}

using Nucleo.Compartilhado.Dominio;

namespace Patio.Dominio.Condutores
{
    public class Condutor : IServicoDeEstacionamento
    {
        public Veiculo Estacionar(string placa)
        {
            return new Veiculo(placa);
        }
    }
}

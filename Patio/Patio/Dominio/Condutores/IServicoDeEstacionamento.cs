using Nucleo.Compartilhado.Dominio;

namespace Patio.Dominio.Condutores
{
    public interface IServicoDeEstacionamento
    {
        Veiculo Estacionar(string placa);
    }
}

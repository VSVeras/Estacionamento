using Nucleo.Compartilhado.Dominio.Condutores;

namespace Patio.Dominio.Condutores
{
    public interface IServicoDeEstacionamento
    {
        Veiculo Estacionar(string placa);
    }
}

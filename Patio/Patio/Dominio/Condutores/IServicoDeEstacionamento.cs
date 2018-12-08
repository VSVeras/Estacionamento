using Nucleo.Compartilhado.Dominio.Veiculos;

namespace Patio.Dominio.Condutores
{
    public interface IServicoDeEstacionamento
    {
        Veiculo Estacionar(string placa);
    }
}

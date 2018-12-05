using Nucleo.Compartilhado.Dominio;

namespace Patio.Dominio.Condutores
{
    // Serviço de domínio deve ser representado por contrato "IServicoDeEstacionamento"
    // Server para: 
    // Transformar um objeto entre uma composição e outra
    // Orquestra entidades e objetos e encapsulam politicas e processos
    // Não deve possuir estado 
    public sealed class Condutor : IServicoDeEstacionamento
    {
        public Veiculo Estacionar(string placa)
        {
            return new Veiculo(placa);
        }
    }
}

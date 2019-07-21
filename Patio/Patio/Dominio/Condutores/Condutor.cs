using Nucleo.Compartilhado.Dominio.Condutores;
using Nucleo.Compartilhado.Dominio.Veiculos;

namespace Patio.Dominio.Condutores
{
    // Serviço de domínio deve ser representado por um contrato "IServicoDeEstacionamento" e serve para: 
    // Transformar um objeto entre uma composição e outra
    // Orquestra entidades e objetos e encapsulam politicas e processos
    // Não deve possuir estado 
    public sealed class Condutor : IServicoDeEstacionamento
    {
        public Veiculo Estacionar(string placa)
        {
            var novaPlaca = new Placa(placa);
            return new Veiculo(novaPlaca);
        }
    }
}

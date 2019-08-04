using Nucleo.Compartilhado.Dominio;
using Patio.Dominio.Condutores;
using Patio.Dominio.Tickets;

namespace Patio.Dominio.RegistroDeEntradas
{
    // Uso de fabrica para simplificar a criação do objeto Ticket por DSL.
    public sealed class RegistroDeEntrada
    {
        public static Ticket Criar(IProvedorDoTempo provedorDoTempo, IServicoDeEstacionamento servicoDeEstacionamento, string placa)
        {
            var ticket = new Ticket(provedorDoTempo);
            var veiculo = servicoDeEstacionamento.Estacionar(placa);
            ticket.Entrada(veiculo);

            return ticket;
        }
    }
}

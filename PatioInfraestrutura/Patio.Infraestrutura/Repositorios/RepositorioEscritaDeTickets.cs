using Patio.Dominio.Tickets;

namespace Patio.Infraestrutura.Repositorios
{
    public sealed class RepositorioEscritaDeTickets : IRepositorioDeEscritaTickets
    {
        public RepositorioEscritaDeTickets()
        {
        }

        public void Salvar(Ticket ticket)
        {
            try
            {
                if (ticket.Valido())
                {

                }
            }
            catch
            {
                throw;
            }
        }
    }
}

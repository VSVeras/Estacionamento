using Patio.Dominio.Tickets;

namespace Patio.Infraestrutura.Repositorios
{
    public sealed class RepositorioDeEscritaDeTickets : IRepositorioDeEscritaTickets
    {
        public RepositorioDeEscritaDeTickets()
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

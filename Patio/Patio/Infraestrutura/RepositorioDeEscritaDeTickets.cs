using Patio.Dominio.Tickets;
using System.Collections.Generic;
using System.Linq;

namespace Patio.Infraestrutura
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

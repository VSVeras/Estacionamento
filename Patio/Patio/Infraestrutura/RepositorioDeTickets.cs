using Patio.Dominio.Tickets;
using System.Collections.Generic;
using System.Linq;

namespace Patio.Infraestrutura
{
    public sealed class RepositorioDeTickets : IRepositorioDeEscritaTickets, IRepositorioDeLeituraTickets
    {
        public RepositorioDeTickets()
        {
        }

        public Ticket ObterPor(int Id)
        {
            try
            {
                return null;
            }
            catch
            {
                throw;
            }
        }

        public Ticket ObterUltimo()
        {
            try
            {
                return new List<Ticket>().AsQueryable().Where(UltimoTicket.Hoje).OrderByDescending(ordem => ordem.DataHoraDeEntrada).FirstOrDefault();
            }
            catch
            {
                throw;
            }
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

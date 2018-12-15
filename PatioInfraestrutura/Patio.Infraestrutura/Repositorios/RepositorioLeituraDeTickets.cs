using Patio.Dominio.Tickets;
using System.Collections.Generic;
using System.Linq;

namespace Patio.Infraestrutura.Repositorios
{
    public sealed class RepositorioLeituraDeTickets : IRepositorioDeLeituraTickets
    {
        public RepositorioLeituraDeTickets()
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
    }
}

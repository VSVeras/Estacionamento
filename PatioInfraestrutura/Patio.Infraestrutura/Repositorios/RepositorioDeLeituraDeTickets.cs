using NHibernate;
using Nucleo.Compartilhado.Comum.Infraestrutura.Persistencia;
using Patio.Dominio.Tickets;
using System.Linq;

namespace Patio.Infraestrutura.Repositorios
{
    public sealed class RepositorioDeLeituraDeTickets : IRepositorioDeLeituraTickets
    {
        public Ticket ObterPor(int id)
        {
            try
            {
                using (ISession sessao = SessionNHibernate.Criar().OpenSession())
                {
                    return sessao.Query<Ticket>().FirstOrDefault(onde => onde.Id == id);
                }
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
                using (ISession sessao = SessionNHibernate.Criar().OpenSession())
                {
                    return sessao.Query<Ticket>().AsQueryable()
                        .Where(UltimoTicket.Hoje)
                        .OrderByDescending(ordem => ordem.DataHoraDeEntrada)
                        .FirstOrDefault();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

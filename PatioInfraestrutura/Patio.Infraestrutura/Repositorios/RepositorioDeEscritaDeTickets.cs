using NHibernate;
using Nucleo.Compartilhado.Comum.Infraestrutura.Persistencia;
using Patio.Dominio.Tickets;

namespace Patio.Infraestrutura.Repositorios
{
    public sealed class RepositorioDeEscritaDeTickets : IRepositorioDeEscritaTickets
    {
        public void Salvar(Ticket ticket)
        {
            try
            {
                if (ticket.Valido())
                {
                    using (ISession sessao = SessionNHibernate.Criar().OpenSession())
                    {
                        using (ITransaction trasacao = sessao.BeginTransaction())
                        {
                            sessao.SaveOrUpdate(ticket);
                            sessao.Flush();
                            trasacao.Commit();
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

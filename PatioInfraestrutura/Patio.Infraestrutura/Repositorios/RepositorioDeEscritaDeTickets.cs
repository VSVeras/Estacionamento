using NHibernate;
using Nucleo.Compartilhado.Comum.Infraestrutura.Persistencia;
using Patio.Dominio.Tickets;

namespace Patio.Infraestrutura.Repositorios
{
    public sealed class RepositorioDeEscritaDeTickets : IRepositorioDeEscritaTickets
    {
        public void Salvar(Ticket ticket)
        {
            if (ticket.Valido())
            {
                try
                {
                    using (ISession sessao = SessionNHibernate.Criar().OpenSession())
                    {
                        using (ITransaction trasacao = sessao.BeginTransaction())
                        {
                            try
                            {
                                sessao.SaveOrUpdate(ticket);
                                sessao.Flush();
                                trasacao.Commit();
                            }
                            catch
                            {
                                trasacao.Rollback();
                                throw;
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
}

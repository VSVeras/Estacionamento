using Patio.Dominio.Tickets;

namespace Patio.Aplicacao.Repositorios
{
    public interface IRepositorioDeLeituraTickets
    {
        Ticket ObterPor(int Id);
        Ticket ObterUltimo();
    }
}

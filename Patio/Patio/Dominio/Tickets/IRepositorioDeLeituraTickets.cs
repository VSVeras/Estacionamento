namespace Patio.Dominio.Tickets
{
    public interface IRepositorioDeLeituraTickets
    {
        Ticket ObterPor(int id);
        Ticket ObterUltimo();
    }
}

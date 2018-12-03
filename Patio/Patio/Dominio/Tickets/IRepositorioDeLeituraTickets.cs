namespace Patio.Dominio.Tickets
{
    public interface IRepositorioDeLeituraTickets
    {
        Ticket ObterPor(int Id);
        Ticket ObterUltimo();
    }
}

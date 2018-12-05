namespace Nucleo.Compartilhado.Dominio
{
    public interface IServicoDeCondutor
    {
        Bilhete ObterTicketEmitidoPor(int id);
    }
}

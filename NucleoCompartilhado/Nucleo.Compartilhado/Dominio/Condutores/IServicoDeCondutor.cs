// Sobre a organização dos módulos: Eles devem ser o índice das histórias.
namespace Nucleo.Compartilhado.Dominio.Condutores
{
    public interface IServicoDeCondutor
    {
        Bilhete ObterTicketEmitidoPor(int id);
    }
}

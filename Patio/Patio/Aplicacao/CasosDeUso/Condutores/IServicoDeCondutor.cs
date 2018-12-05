using Nucleo.Compartilhado.Dominio;

namespace Patio.Aplicacao.CasosDeUso.Condutores
{
    public interface IServicoDeCondutor
    {
        Bilhete ObterTicketEmitidoPor(int id);
    }
}

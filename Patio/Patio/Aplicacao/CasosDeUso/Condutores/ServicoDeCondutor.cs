using Nucleo.Compartilhado.Dominio;
using Patio.Dominio.Tickets;

namespace Patio.Aplicacao.CasosDeUso.Condutores
{
    // Serviço destinado para uso do contexto do checkout
    public sealed class ServicoDeCondutor : IServicoDeCondutor
    {
        private readonly IRepositorioDeLeituraTickets _repositorioDeLeituraTickets;

        public ServicoDeCondutor(IRepositorioDeLeituraTickets repositorioDeLeituraTickets)
        {
            _repositorioDeLeituraTickets = repositorioDeLeituraTickets;
        }

        public Bilhete ObterTicketEmitidoPor(int id)
        {
            try
            {
                var ticket = _repositorioDeLeituraTickets.ObterPor(id);
                return new Bilhete(ticket.Id, ticket.DataHoraDeEntrada, ticket.Veiculo);
            }
            catch
            {
                throw;
            }
        }
    }
}

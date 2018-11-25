using Patio.Aplicacao.CasoDeUso;
using Patio.Aplicacao.Repositorios;

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

        public ObterTicketEmitido ObterTicketEmitidoPor(int id)
        {
            try
            {
                var ticket = _repositorioDeLeituraTickets.ObterPor(id);
                return new ObterTicketEmitido(ticket.Id, ticket.Veiculo.Placa, ticket.DataHoraDeEntrada);
            }
            catch
            {
                throw;
            }
        }
    }
}

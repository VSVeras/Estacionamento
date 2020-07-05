using Nucleo.Compartilhado.Dominio.Condutores;
using Patio.Dominio.Tickets;

namespace Patio.Dominio.Condutores
{
    // Serviço destinado para uso do contexto de checkout
    public sealed class ServicoDeCondutor : IServicoDeCondutor
    {
        private readonly IRepositorioDeLeituraTickets _repositorioDeLeituraTickets;

        public ServicoDeCondutor(IRepositorioDeLeituraTickets repositorioDeLeituraTickets)
        {
            _repositorioDeLeituraTickets = repositorioDeLeituraTickets;
        }

        // Deve obedecer ao contrato "IServicoDeCondutor" entre o contexto de Pátio/Checkout para retornar o Bilhete
        public Bilhete ObterBilheteEmitidoPor(int id)
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

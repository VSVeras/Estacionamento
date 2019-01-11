using Nucleo.Compartilhado.Dominio.Condutores;
using Patio.Dominio.Tickets;

namespace Patio.Aplicacao.Condutores
{
    // OBS.: Essa camada poderia ser simplesmente uma camada CRUD tradicional, para fins didáticos resolvemos criar usando conceitos do DDD.
    // Se a equipe fosse usar REST com certeza iriamos usar o pipeline de middleware do .NET Core para suprimir essa camada, como pode ser visto em: 
    // https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/middleware/index?view=aspnetcore-2.2
    // Existe também a premissa segundo o Martin Fowler: Por que devemos criar um modelo rico? A resposta foi, por que não devemos começar com um modelo rico?

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

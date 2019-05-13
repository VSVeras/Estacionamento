using Nucleo.Compartilhado.Comum.Dominio;

namespace CheckOut.Dominio.Recebimentos
{
    public sealed class Recebimento : Entidade
    {
        public Ticket Ticket { get; private set; }
  
        public TransacoesFinanceiras TransacoesFinanceiras { get; private set; }

        public decimal TotalAPagar { get; private set; }

        public Recebimento()
        {
            TransacoesFinanceiras = new TransacoesFinanceiras();
        }

        public void Conferir(Ticket ticket)
        {
            if(ticket.Permanencia.Saida != null)
                Ticket = ticket;
        }

        public void CobrancaPorPermanencia(IRegraDeCobranca regraDeCobranca)
        {
            if(Ticket != null)
            {
                if(Ticket.Permanencia.Saida != null)
                    TotalAPagar = regraDeCobranca.Calcular(Ticket.Permanencia);
            }
        }

        public void Registrar(TransacaoFinanceira transacaoFinanceira)
        {
            if (TotalAPagar > 0.00m)
                TransacoesFinanceiras.Adicionar(transacaoFinanceira);

        }

        public decimal TotalDasTransacoesFinanceiras()
        {
            return TransacoesFinanceiras.Transacoes.Count > 0 ? TransacoesFinanceiras.Total() : 0.00m;
        }
    }
}

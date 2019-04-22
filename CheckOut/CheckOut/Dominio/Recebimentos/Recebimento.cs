using Nucleo.Compartilhado.Comum.Dominio;
using System.Collections.Generic;

namespace CheckOut.Dominio.Recebimentos
{
    public sealed class Recebimento : Entidade
    {
        public Ticket Ticket { get; private set; }
        private readonly TransacoesFinanceiras _transacoesFinanceiras;
  
        public IReadOnlyCollection<TransacaoFinanceira> TransacoesFinanceiras
        {
            get { return _transacoesFinanceiras.Transacoes(); }
        }

        public decimal TotalAPagar { get; private set; }

        public Recebimento()
        {
            _transacoesFinanceiras = new TransacoesFinanceiras();
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
                _transacoesFinanceiras.Adicionar(transacaoFinanceira);

        }

        public decimal TotalDasTransacoesFinanceiras()
        {
            return _transacoesFinanceiras.Transacoes().Count > 0 ? _transacoesFinanceiras.Total() : 0.00m;
        }
    }
}

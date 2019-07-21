using System.Collections.Generic;
using System.Linq;

namespace CheckOut.Dominio.Recebimentos
{
    public sealed class TransacoesFinanceiras
    {
        private readonly IList<TransacaoFinanceira> _trasacoesFinanceira;
        public IReadOnlyCollection<TransacaoFinanceira> Transacoes { get { return _trasacoesFinanceira.ToList(); }  }

        public TransacoesFinanceiras()
        {
            _trasacoesFinanceira = new List<TransacaoFinanceira>();
        }

        public void Adicionar(TransacaoFinanceira transacao)
        {
            _trasacoesFinanceira.Add(transacao);
        }

        public decimal Total()
        {
            return _trasacoesFinanceira.Sum(campo => campo.ValorRecebido);
        }
    }
}

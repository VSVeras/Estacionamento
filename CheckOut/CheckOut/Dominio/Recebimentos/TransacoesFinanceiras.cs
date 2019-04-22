using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CheckOut.Dominio.Recebimentos
{
    public sealed class TransacoesFinanceiras
    {
        private readonly IList<TransacaoFinanceira> _trasacoesFinanceira;

        public TransacoesFinanceiras()
        {
            _trasacoesFinanceira = new List<TransacaoFinanceira>();
        }

        public IReadOnlyCollection<TransacaoFinanceira> Transacoes()
        {
            return new ReadOnlyCollection<TransacaoFinanceira>(_trasacoesFinanceira);
        }

        public void Adicionar(TransacaoFinanceira transacao)
        {
            _trasacoesFinanceira.Add(transacao);
        }

        public decimal Total()
        {
            return _trasacoesFinanceira.ToList().Sum(campo => campo.ValorRecebido);
        }
    }
}

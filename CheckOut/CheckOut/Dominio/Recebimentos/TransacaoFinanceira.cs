using Nucleo.Compartilhado.Comum.Dominio;

namespace CheckOut.Dominio.Recebimentos
{
    public class TransacaoFinanceira : ObjetoDeValor<TransacaoFinanceira>
    {
        public FormaDePagamento FormaDePagamento { get; }
        public decimal ValorRecebido { get; }

        public TransacaoFinanceira(FormaDePagamento formaDePagamento, decimal valorRecebido)
        {
            FormaDePagamento = formaDePagamento;
            ValorRecebido = valorRecebido;
        }
    }
}
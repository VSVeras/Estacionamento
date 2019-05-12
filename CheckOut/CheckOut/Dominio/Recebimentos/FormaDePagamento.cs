using System.Collections.Generic;

namespace CheckOut.Dominio.Recebimentos
{
    // Em JAVA, enum é uma classe já em C# não, será necessário uma implementação para dar maior 
    // legibilidade ao código e evitar a obsessão por tipos primitivos
    // Exemplos: 
    // https://refactoring.guru/smells/primitive-obsession
    // https://stackoverflow.com/questions/469287/c-sharp-vs-java-enum-for-those-new-to-c/4778347
    public sealed class FormaDePagamento
    {
        public int Id { get; }
        public string Descricao { get; }

        public static readonly FormaDePagamento Dinheiro = new FormaDePagamento(1, "Dinheiro");
        public static readonly FormaDePagamento CartaoDeDebito = new FormaDePagamento(2, "Cartão de Débito");

        public static IEnumerable<FormaDePagamento> Itens
        {
            get
            {
                yield return Dinheiro;
                yield return CartaoDeDebito;
            }
        }

        public FormaDePagamento(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}

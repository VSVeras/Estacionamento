using Nucleo.Compartilhado.Comum.Dominio;
using System;

namespace Nucleo.Compartilhado.Dominio
{
    // Não exige tradução com uma ACL, os dados são simples e pode ser compartilhado
    public sealed class Bilhete : ObjetoDeValor<Bilhete>
    {
        public int TicketId { get; }
        public Veiculo Veiculo { get; }
        public DateTime DataHoraDeEntrada { get; }

        public Bilhete(int ticketId, DateTime dataHoraDeEntrada, Veiculo veiculo)
        {
            TicketId = ticketId;
            DataHoraDeEntrada = dataHoraDeEntrada;
            Veiculo = veiculo;
        }
    }
}

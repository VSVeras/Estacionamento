using Nucleo.Compartilhado.Dominio;
using Nucleo.Compartilhado.Dominio.Veiculos;
using System;

namespace CheckOut.Dominio.Recebimentos
{
    // Mantido o nome de ticket ao invés de identificação, o bilhete 
    // é o que o cliente leva impresso com os dados do ticket.
    public sealed class Ticket
    {
        public int Id { get; private set; }
        public Veiculo Veiculo { get; private set; }
        public Periodo Permanencia { get; private set; }

        public Ticket(int ticketId, DateTime ataHoraDeEntrada, Veiculo veiculo)
        {
            Id = ticketId;
            Veiculo = veiculo;
            Permanencia = new Periodo(ataHoraDeEntrada);
        }

        public void Saida(IProvedorDoTempo provedorDoTempo)
        {
            Permanencia = new Periodo(Permanencia.Entrada, provedorDoTempo);
        }
    }
}

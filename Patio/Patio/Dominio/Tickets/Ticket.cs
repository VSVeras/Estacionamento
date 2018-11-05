using Nucleo.Compartilhado.Comum.Dominio;
using Nucleo.Compartilhado.Dominio;
using System;

namespace Patio.Dominio.Tickets
{
    public class Ticket
    {
        public int Id { get; private set; }
        public Veiculo Veiculo { get; private set; }
        public DateTime DataHoraDeEntrada { get; private set; }

        private readonly IProvedorDoTempo _provedorDoTempo;

        public Ticket(IProvedorDoTempo provedorDeDataHora)
        {
            _provedorDoTempo = provedorDeDataHora;
        }

        public void Entrada(Veiculo veiculo)
        {
            if (Veiculo != null) return;

            Veiculo = veiculo;
            DataHoraDeEntrada = _provedorDoTempo.DataHora;
        }

        internal bool Valido()
        {
            if (Veiculo != null)
                return false;

            return true;
        }
    }
}

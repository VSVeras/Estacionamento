using Nucleo.Compartilhado.Comum.Dominio;
using Nucleo.Compartilhado.Dominio;
using Nucleo.Compartilhado.Dominio.Condutores;
using System;

namespace Patio.Dominio.Tickets
{
    // A raiz do agregado dever atender a todos os fluxos do caso de uso.
    public sealed class Ticket : Entidade
    {
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
            if (Veiculo == null)
                return false;

            if (DataHoraDeEntrada == null)
                return false;

            return true;
        }
    }
}

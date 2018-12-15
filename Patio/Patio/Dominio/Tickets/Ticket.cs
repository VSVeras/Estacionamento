using Nucleo.Compartilhado.Comum.Dominio;
using Nucleo.Compartilhado.Dominio;
using Nucleo.Compartilhado.Dominio.Veiculos;
using System;

namespace Patio.Dominio.Tickets
{
    // A raiz do agregado dever atender a todos os fluxos do caso de uso.
    public class Ticket : Agregado
    {
        public virtual Veiculo Veiculo { get; private set; }
        public virtual DateTime DataHoraDeEntrada { get; private set; }

        private readonly IProvedorDoTempo _provedorDoTempo;

        public Ticket(IProvedorDoTempo provedorDeDataHora)
        {
            _provedorDoTempo = provedorDeDataHora;
        }

        public virtual void Entrada(Veiculo veiculo)
        {
            if (Veiculo != null) return;

            Veiculo = veiculo;
            DataHoraDeEntrada = _provedorDoTempo.DataHora;
        }

        public virtual bool Valido()
        {
            if (Veiculo == null)
                return false;

            if (DataHoraDeEntrada == null)
                return false;

            return true;
        }
    }
}

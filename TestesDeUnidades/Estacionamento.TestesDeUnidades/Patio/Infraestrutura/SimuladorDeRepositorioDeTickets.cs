using Estacionamento.TestesDeUnidades.NucleoCompartilhado.Infraestrutura.SistemaOperacional;
using Nucleo.Compartilhado.Dominio;
using Nucleo.Compartilhado.Dominio.Veiculos;
using Patio.Dominio.Tickets;
using System;

namespace Estacionamento.TestesDeUnidades.Patio.Infraestrutura
{
    public class SimuladorDeRepositorioDeTickets : IRepositorioDeLeituraTickets
    {
        private readonly IProvedorDoTempo _provedorDeDataHora;
        private readonly Veiculo _veiculo;

        public SimuladorDeRepositorioDeTickets(IProvedorDoTempo provedorDeDataHora, Veiculo veiculo)
        {
            this._provedorDeDataHora = provedorDeDataHora;
            this._veiculo = veiculo;
        }

        public Ticket ObterPor(int Id)
        {
            var ticket = new Ticket(_provedorDeDataHora);
            ticket.Entrada(_veiculo);

            return ticket;
        }

        public Ticket ObterUltimo()
        {
            var ticket = new Ticket(_provedorDeDataHora);
            ticket.Entrada(_veiculo);

            return ticket;
        }
    }
}

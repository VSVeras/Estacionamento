using Nucleo.Compartilhado.Dominio;
using Nucleo.Compartilhado.Dominio.Veiculos;
using Patio.Dominio.Tickets;

namespace Estacionamento.TestesDeUnidades.Patio.Infraestrutura
{
    public class SimuladorDeRepositorioDeLeituraDeTickets : IRepositorioDeLeituraTickets
    {
        private readonly IProvedorDoTempo _provedorDeDataHora;
        private readonly Veiculo _veiculo;

        public SimuladorDeRepositorioDeLeituraDeTickets(IProvedorDoTempo provedorDeDataHora, Veiculo veiculo)
        {
            _provedorDeDataHora = provedorDeDataHora;
            _veiculo = veiculo;
        }

        public Ticket ObterPor(int id)
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

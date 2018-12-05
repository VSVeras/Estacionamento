using Nucleo.Compartilhado.Dominio;
using Patio.Aplicacao.CasoDeUso;
using Patio.Dominio.Atendentes;
using Patio.Dominio.Condutores;
using Patio.Dominio.Tickets;

namespace Patio.Aplicacao.Atendentes
{
    // Serviços de aplicação serve para orquestrar as operações dos casos de uso.
    public sealed class ServidoDeAtendimento : IServidoDeAtendimento
    {
        private readonly IRepositorioDeLeituraTickets _repositorioDeLeituraTickets;
        private readonly IRepositorioDeEscritaTickets _repositorioDeEscritaTickets;
        private readonly IProvedorDoTempo _provedorDoTempo;
        private readonly IServicoDeEstacionamento _servicoDeEstacionamento;

        public ServidoDeAtendimento(IRepositorioDeLeituraTickets repositorioDeLeituraTickets, IRepositorioDeEscritaTickets repositorioDeEscritaTickets, 
                                    IProvedorDoTempo provedorDoTempo, IServicoDeEstacionamento servicoDeEstacionamento)
        {
            _repositorioDeLeituraTickets = repositorioDeLeituraTickets;
            _repositorioDeEscritaTickets = repositorioDeEscritaTickets;
            _provedorDoTempo = provedorDoTempo;
            _servicoDeEstacionamento = servicoDeEstacionamento;
        }

        public void Registrar(EntradaDeUmVeiculo entradaDeUmVeiculo)
        {
            try
            {
                var ticket = Atendente.Registrar.Entrada(_provedorDoTempo, _servicoDeEstacionamento, entradaDeUmVeiculo.Placa);
                _repositorioDeEscritaTickets.Salvar(ticket);
            }
            catch
            {
                throw;
            }
        }

        public ObterUltimoTicket EmissaoDeTicket()
        {
            try
            {
                var ticket = _repositorioDeLeituraTickets.ObterUltimo();
                return new ObterUltimoTicket(ticket.Id, ticket.Veiculo.Placa, ticket.DataHoraDeEntrada);
            }
            catch
            {
                throw;
            }
        }
    }
}

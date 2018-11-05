﻿using Nucleo.Compartilhado.Comum.Dominio;
using Patio.Aplicacao.CasoDeUso;
using Patio.Aplicacao.Repositorios;
using Patio.Dominio.Atendentes;
using Patio.Dominio.Condutores;

namespace Patio.Aplicacao.Atendentes
{
    public class ServidoDeAtendente : IServidoDeAtendente
    {
        private readonly IRepositorioDeLeituraTickets _repositorioDeLeituraTickets;
        private readonly IRepositorioDeEscritaTickets _repositorioDeEscritaTickets;
        private readonly IProvedorDoTempo _provedorDoTempo;
        private readonly IServicoDeEstacionamento _servicoDeEstacionamento;

        public ServidoDeAtendente(IRepositorioDeLeituraTickets repositorioDeLeituraTickets, IRepositorioDeEscritaTickets repositorioDeEscritaTickets, 
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

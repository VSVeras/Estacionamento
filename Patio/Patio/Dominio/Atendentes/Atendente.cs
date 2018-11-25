﻿using Nucleo.Compartilhado.Comum.Dominio;
using Patio.Dominio.Condutores;
using Patio.Dominio.Tickets;

namespace Patio.Dominio.Atendentes
{
    public sealed class Atendente
    {
        public static class Registrar
        {
            public static Ticket Entrada(IProvedorDoTempo provedorDoTempo, IServicoDeEstacionamento servicoDeEstacionamento, string placa)
            {
                var ticket = new Ticket(provedorDoTempo);
                var veiculo = servicoDeEstacionamento.Estacionar(placa);
                ticket.Entrada(veiculo);

                return ticket;
            }
        }
    }
}
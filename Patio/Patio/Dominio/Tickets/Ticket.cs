﻿using Nucleo.Compartilhado.Comum.Dominio;
using Nucleo.Compartilhado.Dominio;
using Nucleo.Compartilhado.Dominio.Veiculos;
using System;

namespace Patio.Dominio.Tickets
{
    // A raiz do agregado dever atender a todos os fluxos do caso de uso.
    public class Ticket : Agregado
    {
        // O virtual é necessário para o Hibernate fazer o proxy
        public virtual Veiculo Veiculo { get; protected set; }
        public virtual DateTime DataHoraDeEntrada { get; protected set; }

        private readonly IProvedorDoTempo _provedorDoTempo;

        protected Ticket() { }

        public Ticket(IProvedorDoTempo provedorDeDataHora)
        {
            if (provedorDeDataHora == null)
                QuebraDeEspeficacao.Adicionar(new RegraDeNegocio("O provedor de data e hora não foi informado."));

            _provedorDoTempo = provedorDeDataHora;
        }

        public virtual void Entrada(Veiculo veiculo)
        {
            if (veiculo == null)
            {
                QuebraDeEspeficacao.Adicionar(new RegraDeNegocio("Veículo não foi informado."));
            }
            else
            {
                if (veiculo.Valido())
                {
                    QuebraDeEspeficacao.Adicionar(veiculo.QuebraDeEspeficacao.RegraDeNegocio);
                }
            }


            if (_provedorDoTempo != null)
            {
                if (_provedorDoTempo.DataHora == DateTime.MinValue)
                {
                    QuebraDeEspeficacao.Adicionar(new RegraDeNegocio("Data de entrada não foi informada."));
                }
            }

            if (!QuebraDeEspeficacao.HouveViolacao())
            {
                Veiculo = veiculo;
                DataHoraDeEntrada = _provedorDoTempo.DataHora;
            }
        }
    }
}

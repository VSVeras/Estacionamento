using Nucleo.Compartilhado.Comum.Dominio;
using System;

namespace Estacionamento.TestesDeUnidades.NucleoCompartilhado.Infraestrutura.SistemaOperacional
{
    public class SimuladorDeDataHoraDoSistema : IProvedorDoTempo
    {
        public DateTime DataHora { get; set; }
    }
}

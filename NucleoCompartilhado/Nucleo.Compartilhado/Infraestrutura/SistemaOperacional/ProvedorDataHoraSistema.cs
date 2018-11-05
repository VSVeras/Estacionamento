using Nucleo.Compartilhado.Comum.Dominio;
using System;

namespace Nucleo.Compartilhado.Infraestrutura.SistemaOperacional
{
    public class ProvedorDataHoraSistema : IProvedorDoTempo
    {
        public DateTime DataHora { get { return DateTime.UtcNow; } }
    }
}

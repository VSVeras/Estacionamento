using Nucleo.Compartilhado.Dominio;
using System;

namespace Nucleo.Compartilhado.Infraestrutura.SistemaOperacional
{
    public sealed class ProvedorDataHoraSistema : IProvedorDoTempo
    {
        public DateTime DataHora { get { return DateTime.UtcNow; } }
    }
}

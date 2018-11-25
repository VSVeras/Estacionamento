using Nucleo.Compartilhado.Comum.Dominio;
using Nucleo.Compartilhado.Dominio;
using System;

namespace CheckOut.Dominio.Recebimentos
{
    public sealed class Periodo : ObjetoDeValor<Periodo>
    { 
        public DateTime Entrada { get; }
        public DateTime Saida { get; }

        public Periodo(DateTime entrada)
        {
            Entrada = entrada;
        }

        public Periodo(DateTime entrada, IProvedorDoTempo saida): this(entrada)
        {
            Saida = saida.DataHora;
        }

        public double PorMinutos()
        {
            if (Saida == null)
                return 0;

            return Saida.Subtract(Entrada).TotalMinutes;
        }

        public double PorDias()
        {
            if (Saida == null)
                return 0;

            return Saida.Subtract(Entrada).TotalDays;
        }
    }
}

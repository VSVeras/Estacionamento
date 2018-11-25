using System;

namespace CheckOut.Dominio.Recebimentos
{
    public sealed class CobrancaPorDiaria : IRegraDeCobranca
    {
        private readonly decimal _valorDaDiaria = 22.00m;

        public decimal Calcular(Periodo permanencia)
        {
            var totalPermanencia = (decimal) permanencia.PorDias();
            return _valorDaDiaria * totalPermanencia;
        }
    }
}

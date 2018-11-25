namespace CheckOut.Dominio.Recebimentos
{
    public sealed class CobrancaPorHora : IRegraDeCobranca
    {
        private readonly int _minutosEmUmaHora = 60;
        private readonly decimal _valorHora = 12.00m;

        public decimal Calcular(Periodo permanencia)
        {
            return _valorHora * (decimal) (permanencia.PorMinutos() / _minutosEmUmaHora);
        }
    }
}

namespace CheckOut.Dominio.Recebimentos
{
    // Abstração para uso do design pattern strategy: https://en.wikipedia.org/wiki/Strategy_pattern
    public interface IRegraDeCobranca
    {
        decimal Calcular(Periodo permanencia);
    }
}

namespace CheckOut.Dominio.Recebimentos
{
    public interface IRegraDeCobranca
    {
        decimal Calcular(Periodo permanencia);
    }
}

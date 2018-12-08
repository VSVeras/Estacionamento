using Nucleo.Compartilhado.Comum.Dominio;

namespace Nucleo.Compartilhado.Dominio.Veiculos
{
    public sealed class Veiculo : ObjetoDeValor<Veiculo>
    {
        public Placa Placa { get; }

        public Veiculo(Placa placa)
        {
            Placa = placa;
        }
    }
}

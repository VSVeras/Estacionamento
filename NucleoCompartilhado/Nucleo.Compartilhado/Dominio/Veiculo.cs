using Nucleo.Compartilhado.Comum.Dominio;

namespace Nucleo.Compartilhado.Dominio
{
    public class Veiculo : ObjetoDeValor<Veiculo>
    {
        public string Placa { get; }

        public Veiculo(string placa)
        {
            Placa = placa;
        }
    }
}

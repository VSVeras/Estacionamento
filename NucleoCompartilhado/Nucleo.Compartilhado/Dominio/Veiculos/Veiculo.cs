using Nucleo.Compartilhado.Comum.Dominio;

namespace Nucleo.Compartilhado.Dominio.Veiculos
{
    public sealed class Veiculo : ObjetoDeValor<Veiculo>
    {
        public Placa Placa { get; }

        public Veiculo(Placa placa)
        {
            if (placa == null)
                QuebraDeEspeficacao.Adicionar(new RegraDeNegocio("A placa do veículo não foi informado."));
            else
            {
                if (placa.Valido())
                    QuebraDeEspeficacao.Adicionar(placa.QuebraDeEspeficacao.RegraDeNegocio);
            }

            Placa = placa;
        }
    }
}

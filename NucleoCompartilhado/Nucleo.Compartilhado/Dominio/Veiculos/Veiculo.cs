using Nucleo.Compartilhado.Comum.Dominio;

namespace Nucleo.Compartilhado.Dominio.Veiculos
{
    public class Veiculo : ObjetoDeValor<Veiculo>
    {
        public virtual Placa Placa { get; protected set; }

        protected Veiculo() { }

        public Veiculo(Placa placa)
        {
            if (placa == null)
                QuebraDeEspeficacao.Adicionar(new RegraDeNegocio("A placa do veículo não foi informada."));
            else
            {
                if (placa.Valido())
                    QuebraDeEspeficacao.Adicionar(placa.QuebraDeEspeficacao.RegraDeNegocio);
            }

            Placa = placa;
        }
    }
}

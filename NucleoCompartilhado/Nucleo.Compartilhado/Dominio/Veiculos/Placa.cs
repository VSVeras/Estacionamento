using Nucleo.Compartilhado.Comum.Dominio;
using System.Text.RegularExpressions;

namespace Nucleo.Compartilhado.Dominio.Veiculos
{
    public class Placa : ObjetoDeValor<Placa>
    {
        public virtual string Valor { get; protected set; }

        protected Placa() { }

        public Placa(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                QuebraDeEspeficacao.Adicionar(new RegraDeNegocio("A identificação da placa não foi informada."));
            else
            {
                var regraValidaDoConteudo = new Regex("[a-zA-Z]{3}[0-9]{4}");
                if (regraValidaDoConteudo.IsMatch(valor))
                    QuebraDeEspeficacao.Adicionar(new RegraDeNegocio("A placa deve conter letras e números"));
            }

            Valor = valor;
        }
    }
}

using Nucleo.Compartilhado.Comum.Dominio;
using System.Text.RegularExpressions;

namespace Nucleo.Compartilhado.Dominio.Veiculos
{
    public sealed class Placa : ObjetoDeValor<Placa>
    {
        public string Valor { get; }

        public Placa(string valor)
        {
            var placaValida = new Regex("[a-zA-Z]{3}[0-9]{4}");
            if (placaValida.IsMatch(valor))
                return;

            Valor = valor;
        }
    }
}

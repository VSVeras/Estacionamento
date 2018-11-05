using System;
using System.Collections.Generic;
using System.Text;

namespace Patio.Aplicacao.CasoDeUso
{
    public class ObterTicketEmitido
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime DataHoraDeEntrada { get; set; }

        public ObterTicketEmitido(int id, string placa, DateTime dataHoraDeEntrada)
        {
            Id = id;
            Placa = placa;
            DataHoraDeEntrada = dataHoraDeEntrada;
        }
    }
}

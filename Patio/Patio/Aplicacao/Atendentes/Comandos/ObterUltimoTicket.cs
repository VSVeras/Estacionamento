using System;

namespace Patio.Aplicacao.Atendentes.Comandos
{
    public class ObterUltimoTicket
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime DataHoraDeEntrada { get; set; }

        public ObterUltimoTicket(int id, string placa, DateTime dataHoraDeEntrada)
        {
            Id = id;
            Placa = placa;
            DataHoraDeEntrada = dataHoraDeEntrada;
        }
    }
}

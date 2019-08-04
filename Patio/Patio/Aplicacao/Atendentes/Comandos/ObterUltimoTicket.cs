using System;

namespace Patio.Aplicacao.Atendentes.Comandos
{
    //O padrão de comando é um padrão de design comportamental no qual um objeto é 
    //usado para encapsular todas as informações necessárias para executar uma ação ou acionar um evento posteriormente.
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

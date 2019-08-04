namespace Patio.Aplicacao.Atendentes.Comandos
{
    //O padrão de comando é um padrão de design comportamental no qual um objeto é 
    //usado para encapsular todas as informações necessárias para executar uma ação ou acionar um evento posteriormente.
    public class EntradaDeUmVeiculo
    {
        public string Placa { get; set; }

        public EntradaDeUmVeiculo(string placa)
        {
            Placa = placa;
        }
    }
}

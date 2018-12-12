using Patio.Aplicacao.Atendentes.Comandos;

namespace Patio.Aplicacao.Atendentes
{
    public interface IServidoDeAtendimento
    {
        void Registrar(EntradaDeUmVeiculo registroDeEntradaDeUmVeiculo);
        ObterUltimoTicket EmissaoDeTicket();
    }
}

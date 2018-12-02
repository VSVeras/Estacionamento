using Patio.Aplicacao.CasoDeUso;

namespace Patio.Aplicacao.Atendentes
{
    public interface IServidoDeAtendimento
    {
        void Registrar(EntradaDeUmVeiculo registroDeEntradaDeUmVeiculo);
        ObterUltimoTicket EmissaoDeTicket();
    }
}

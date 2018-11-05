using Patio.Aplicacao.CasoDeUso;

namespace Patio.Aplicacao.Atendentes
{
    public interface IServidoDeAtendente
    {
        void Registrar(EntradaDeUmVeiculo registroDeEntradaDeUmVeiculo);
        ObterUltimoTicket EmissaoDeTicket();
    }
}

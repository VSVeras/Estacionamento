namespace Nucleo.Compartilhado.Comum.Dominio
{
    public sealed class RegraDeNegocio : ObjetoDeValor<RegraDeNegocio>
    {
        public readonly string Descricao;
        public RegraDeNegocio(string descricao)
        {
            Descricao = descricao;
        }
    }
}

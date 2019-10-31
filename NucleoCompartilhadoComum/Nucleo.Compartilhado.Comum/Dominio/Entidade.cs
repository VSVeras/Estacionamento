namespace Nucleo.Compartilhado.Comum.Dominio
{
    // Próximo passo identificar os agregados e as entidades, lembrar deste:

    // Some objects are not defined primarily by their attributes. 
    // They represent a thread of identity that runs through time and often across distinct representations.
    // An object defined primarily by its identity is called an ENTITY” (Evans, 91)

    public abstract class Entidade : Identidade
    {
        public virtual IEspecificacaoDeNegocio QuebraDeEspeficacao { get; }
        protected Entidade()
        {
            QuebraDeEspeficacao = new QuebraDeEspeficacao();
        }

        public Entidade(IEspecificacaoDeNegocio especificacaoDeNegocio)
        {
            QuebraDeEspeficacao = especificacaoDeNegocio;
        }

        public virtual bool Valido()
        {
            return QuebraDeEspeficacao.HouveViolacao();
        }
    }
}

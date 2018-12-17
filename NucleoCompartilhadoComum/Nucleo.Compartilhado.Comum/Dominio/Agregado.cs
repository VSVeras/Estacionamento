using System.Collections.Generic;
using System.Linq;

namespace Nucleo.Compartilhado.Comum.Dominio
{
    public abstract class Agregado : Entidade
    {
        public virtual IEspecificacaoDeNegocio QuebraDeEspeficacao { get; }

        protected Agregado()
        {
            QuebraDeEspeficacao = new QuebraDeEspeficacao();
        }

        public Agregado(IEspecificacaoDeNegocio especificacaoDeNegocio)
        {
            QuebraDeEspeficacao = especificacaoDeNegocio;
        }

        public bool Valido()
        {
            return QuebraDeEspeficacao.HouveViolacao();
        }
    }
}

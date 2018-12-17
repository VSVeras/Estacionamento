using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Compartilhado.Comum.Dominio
{
    public interface IEspecificacaoDeNegocio
    {
        IEnumerable<RegraDeNegocio> RegraDeNegocio { get; }
        void Adicionar(RegraDeNegocio regraDeNegocio);
        void Adicionar(IEnumerable<RegraDeNegocio> regrasDeNegocio);
        bool Contem(RegraDeNegocio regraDeNegocio);
        bool HouveViolacao();
    }
}

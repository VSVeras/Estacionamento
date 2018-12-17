﻿using System.Collections.Generic;
using System.Linq;

namespace Nucleo.Compartilhado.Comum.Dominio
{
    // Baseado no padrão Notification in Validations cunhado por Martin Fowler: https://martinfowler.com/articles/replaceThrowWithNotification.html
    public sealed class QuebraDeEspeficacao : IEspecificacaoDeNegocio
    {
        private readonly IList<RegraDeNegocio> _regraDeNegocio;
        public IEnumerable<RegraDeNegocio> RegraDeNegocio { get { return _regraDeNegocio; } }

        public QuebraDeEspeficacao()
        {
            _regraDeNegocio = new List<RegraDeNegocio>();
        }

        public void Adicionar(RegraDeNegocio regraDeNegocio)
        {
            if (!Contem(regraDeNegocio))
                _regraDeNegocio.Add(regraDeNegocio);
        }

        public void Adicionar(IEnumerable<RegraDeNegocio> regrasDeNegocio)
        {
            regrasDeNegocio.ToList().ForEach(item => Adicionar(item));
        }

        public bool Contem(RegraDeNegocio regraDeNegocio)
        {
            return _regraDeNegocio.Contains(regraDeNegocio);
        }

        public bool HouveViolacao()
        {
            return _regraDeNegocio.Any();
        }
    }
}

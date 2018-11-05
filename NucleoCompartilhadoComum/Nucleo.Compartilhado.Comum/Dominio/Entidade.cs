using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Compartilhado.Comum.Dominio
{
    public abstract class Entidade : IEquatable<Entidade>
    {
        public virtual int Id { get; protected set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entidade);
        }

        public bool Equals(Entidade entidade)
        {
            if (ReferenceEquals(entidade, null))
                return false;

            if (ReferenceEquals(this, entidade))
                return true;

            if (GetType() != entidade.GetType())
                return false;

            if (!Transitorio() && !entidade.Transitorio() && Id == entidade.Id)
                return true;

            if (Transitorio() || entidade.Transitorio())
                return false;

            return Id == entidade.Id;
        }

        // Para uso dos ORM's
        public virtual bool Transitorio()
        {
            return Id == default(int);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + " Id = " + Id).GetHashCode();
        }

        public static bool operator ==(Entidade umaEntidade, Entidade outraEntidade)
        {
            return EqualityComparer<Entidade>.Default.Equals(umaEntidade, outraEntidade);
        }

        public static bool operator !=(Entidade umaEntidade, Entidade outraEntidade)
        {
            return !(umaEntidade == outraEntidade);
        }
    }
}

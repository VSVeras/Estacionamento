using System;
using System.Collections.Generic;

namespace Nucleo.Compartilhado.Comum.Dominio
{
    // Próximo passo identificar os agregados e entidades, lembrar deste:

    // Some objects are not defined primarily by their attributes. 
    // They represent a thread of identity that runs through time and often across distinct representations.
    // An object defined primarily by its identity is called an ENTITY” (Evans, 91)

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

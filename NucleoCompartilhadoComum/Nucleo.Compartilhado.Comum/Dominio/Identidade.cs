using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Compartilhado.Comum.Dominio
{
   public class Identidade : IEquatable<Identidade>
    {
        public virtual int Id { get; protected set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Identidade);
        }

        public virtual bool Equals(Identidade identidade)
        {
            if (ReferenceEquals(identidade, null))
                return false;

            if (ReferenceEquals(this, identidade))
                return true;

            if (GetType() != identidade.GetType())
                return false;

            if (!Transitorio() && !identidade.Transitorio() && Id == identidade.Id)
                return true;

            if (Transitorio() || identidade.Transitorio())
                return false;

            return Id == identidade.Id;
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

        public static bool operator ==(Identidade umaIdentidade, Identidade outraIdentidade)
        {
            return EqualityComparer<Identidade>.Default.Equals(umaIdentidade, outraIdentidade);
        }

        public static bool operator !=(Identidade umaIdentidade, Identidade outraIdentidade)
        {
            return !(umaIdentidade == outraIdentidade);
        }
    }
}
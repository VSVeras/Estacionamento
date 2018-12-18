using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nucleo.Compartilhado.Comum.Dominio
{
    public abstract class ObjetoDeValor<T> : IEquatable<T> where T : ObjetoDeValor<T>
    {
        public virtual IEspecificacaoDeNegocio QuebraDeEspeficacao { get; }

        protected ObjetoDeValor()
        {
            QuebraDeEspeficacao = new QuebraDeEspeficacao();
        }

        public ObjetoDeValor(IEspecificacaoDeNegocio especificacaoDeNegocio)
        {
            QuebraDeEspeficacao = especificacaoDeNegocio;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            T other = obj as T;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            var fields = GetFields();

            int startValue = 17;
            int multiplier = 59;

            return fields
             .Select(field => field.GetValue(this))
             .Where(value => value != null)
             .Aggregate(
                 startValue,
                     (current, value) => current * multiplier + value.GetHashCode());

        }

        public virtual bool Equals(T other)
        {
            if (other == null)
                return false;

            var t = GetType();
            var otherType = other.GetType();

            if (t != otherType)
                return false;

            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                object value1 = field.GetValue(other);
                object value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                        return false;
                }
                else if (!value1.Equals(value2))
                    return false;
            }

            return true;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            var t = GetType();

            var fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                if (t == null) continue;
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

                t = t.BaseType;
            }

            return fields;
        }

        public static bool operator ==(ObjetoDeValor<T> x, ObjetoDeValor<T> y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (((object)x == null) || ((object)y == null))
                return false;

            if (Equals(null, x))
                return true;

            return x.Equals(y);
        }

        public static bool operator !=(ObjetoDeValor<T> x, ObjetoDeValor<T> y)
        {
            return !(x == y);
        }

        public virtual bool Valido()
        {
            return QuebraDeEspeficacao.HouveViolacao();
        }
    }
}

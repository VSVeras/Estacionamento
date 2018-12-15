using FluentNHibernate;
using FluentNHibernate.Conventions;
using System;

namespace Nucleo.Compartilhado.Comum.Infraestrutura.Persistencia
{
    internal sealed class CustomForeignKeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
                return type.Name + "Id";

            return property.Name + "Id";
        }
    }
}

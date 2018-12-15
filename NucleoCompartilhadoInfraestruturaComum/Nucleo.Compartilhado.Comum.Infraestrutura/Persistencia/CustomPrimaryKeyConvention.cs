using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Nucleo.Compartilhado.Comum.Infraestrutura.Persistencia
{
    internal sealed class CustomPrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column("Id");
        }
    }
}

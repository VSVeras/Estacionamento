using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace Nucleo.Compartilhado.Comum.Infraestrutura.Persistencia
{
    public class SessionNHibernate
    {
        public static ISessionFactory Criar()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString("SOFTDomain"))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                .Conventions.Add<CustomPrimaryKeyConvention>()
                .Conventions.Add<CustomForeignKeyConvention>()
                .Conventions.Add<CustomManyToManyTableNameConvention>())
                .ExposeConfiguration(configuracao =>
                {
                    configuracao.SetProperty("command_timeout", "45");
                    new SchemaExport(configuracao).Drop(true, true);
                    new SchemaExport(configuracao).Create(true, true);
                })
                .BuildSessionFactory();

            return sessionFactory;
        }
    }
}

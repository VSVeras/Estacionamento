using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nucleo.Compartilhado.Comum.Infraestrutura.Persistencia
{
    public class SessionNHibernate
    {
        // O banco de dados tem que ser criado na unha "Como diz o ditado popular".
        // TODO Refatorar assim que possível, a string de conexão não pode ficar fixa da forma que está.
        public static ISessionFactory Criar()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=localhost,1433;Initial Catalog=Estacionamento;Persist Security Info=True;User ID=sa;Pwd=./abre7eses@mo;MultipleActiveResultSets=True;"))
                .Mappings(todos =>
                {
                    ObterBinarios().ForEach(assembly =>
                    {
                        todos.FluentMappings.AddFromAssembly(Assembly.Load(assembly.GetName()));
                    });
                })
                .Mappings(x => x.FluentMappings
                .Conventions.Add<CustomPrimaryKeyConvention>()
                .Conventions.Add<CustomForeignKeyConvention>()
                .Conventions.Add<CustomManyToManyTableNameConvention>())
                .ExposeConfiguration(configuracao =>
                {
                    configuracao.SetProperty("command_timeout", "45");

                    // TODO Habilitar as linhas abaixo quando houver alteração modelo.
                    // new SchemaExport(configuracao).Drop(true, true); 
                    // new SchemaExport(configuracao).Create(true, true);
                })
                .BuildSessionFactory();

            return sessionFactory;
        }

        private static List<Assembly> ObterBinarios()
        {
            List<Assembly> todosOsBinarios = new List<Assembly>();
            string caminhoDaAplicacao = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Directory.GetFiles(caminhoDaAplicacao, "*.Infraestrutura.dll").ToList().ForEach(file =>
            {
                todosOsBinarios.Add(Assembly.LoadFile(file));
            });

            return todosOsBinarios;
        }
    }
}

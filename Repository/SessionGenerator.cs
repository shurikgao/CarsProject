using System.Text;
using DomainMapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Repository
{
    public class SessionGenerator
    {
        #region Non-public members

        private SessionGenerator()
        {
        }

        #endregion

        #region Public static members

        public static SessionGenerator Instance
        {
            get { return _sessionGenerator; }
        }

        #endregion

        #region Public members

        public ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }

        #endregion

        #region Non-public static members

        private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();
        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(
                        builder =>
                            builder.Database(
                                "MyDB_NHib")
                                .Server(
                                    @"ALEX-PC")
                                .TrustedConnection()))
                //.Mappings(x =>x.FluentMappings.AddFromAssembly(typeof (CarMap).Assembly))
                .Mappings(cfg => CreateMappings(cfg))
                .ExposeConfiguration(
                    cfg => new SchemaUpdate(cfg).Execute(false, true));

            var conf = configuration.BuildConfiguration();

            var stringBuilder = new StringBuilder();
            new SchemaExport(conf).Execute(entry => stringBuilder.Append(entry), false, false);
            return configuration.BuildSessionFactory();
        }

        private static void CreateMappings(MappingConfiguration mappingConfiguration)
        {
            var assembly = (typeof (CarMap).Assembly);

            mappingConfiguration.FluentMappings.AddFromAssembly(assembly);
            mappingConfiguration.HbmMappings.AddFromAssembly(assembly);
        }

        #endregion
    }
}
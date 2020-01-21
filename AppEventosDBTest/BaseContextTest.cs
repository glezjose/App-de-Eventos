using AppEventos.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEventosDBTest
{
    [TestClass]
    public abstract class BaseContextTest
    {
        protected EventoContext ctx;

        [TestInitialize]
        public virtual void OnSetUp()
        {
            string testDatabase = $"Server=(localdb)\\mssqllocaldb;Database=app_db_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true";
            var serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<EventoContext>();

            builder
                .EnableSensitiveDataLogging()
                .UseSqlServer(testDatabase)
                .UseInternalServiceProvider(serviceProvider);
            ctx = new EventoContext(builder.Options);
            ctx.Database.Migrate();//genera la migraci�n para la Bd mdf en memoria.
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            ctx.Database.EnsureDeletedAsync();
        }
    }
}

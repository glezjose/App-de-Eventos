using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEventos.Modelo
{
    public class EventoContext: DbContext
    {
        public EventoContext() { }
        public EventoContext(DbContextOptions<EventoContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BOT-JGONZALEZA;Database=AppEventosDB;Trusted_Connection=True;");
        }
    }
}

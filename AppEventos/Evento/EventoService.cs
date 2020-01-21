using AppEventos.Modelo;
using System.Collections.Generic;
using System.Linq;

namespace AppEventos.Evento
{
    public class EventoService
    {
        private readonly EventoContext ctx;
        public EventoService(EventoContext _ctx)
        {
            ctx = _ctx;
        }
        public void InsertarEvento(Modelo.Evento evento)
        {
            ctx.Eventos.Add(evento);

            ctx.SaveChanges();
        }

        public List<Modelo.Evento> ObtenerEventosPorNombre(string cNombre)
        {
            List<Modelo.Evento> _lstEventos = ctx.Eventos
                                                 .Where(e => e.Nombre == cNombre)
                                                 .ToList();

            return _lstEventos;
        }
    }
}

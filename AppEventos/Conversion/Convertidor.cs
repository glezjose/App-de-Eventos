using AppEventos.Evento;
using AppEventos.Modelo;
using System;

namespace AppEventos.Conversion
{
    public class Convertidor : IConvertidor
    {
        private readonly EventoService eventoService;
        public Convertidor(EventoService eventoService)
        {
            this.eventoService = eventoService;
        }

        public Lectura.Evento ConvertirEvento(string cEvento)
        {
            Lectura.Evento _evento;
            try
            {
                string[] _arrayEventos = cEvento.Split(',');

                _evento = new Lectura.Evento { cNombre = _arrayEventos[0], dtFecha = Convert.ToDateTime(_arrayEventos[1]) };

                Modelo.Evento evento = new Modelo.Evento { Nombre = _evento.cNombre, Fecha = _evento.dtFecha };

                eventoService.InsertarEvento(evento);

            }
            catch (IndexOutOfRangeException)
            {

                throw new IndexOutOfRangeException("Indice fuera de rango, posiblemente alguna linea del archivo no cumpla con el formato adecuado de eventos.");
            }
            return _evento;
        }
    }
}

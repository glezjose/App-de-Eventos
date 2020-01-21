using AppEventos.Lectura;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEventos.Manejo
{
    public abstract class ManejadorRangos : IManejadorRangos
    {
        private IManejadorRangos manejador;
        public void AsignarSiguiente(IManejadorRangos manejador)
        {
            this.manejador = manejador;
        }

        public void EvaluarEvento(Lectura.Evento evento)
        {
            if (!PersistirEvento(evento))
            {
                manejador?.EvaluarEvento(evento);
            }
        }

        protected abstract bool PersistirEvento(Lectura.Evento evento);

        protected abstract string ObtenerMensaje(string cNombre, string cOcurrencia, double dRangoTiempo);
    }
}

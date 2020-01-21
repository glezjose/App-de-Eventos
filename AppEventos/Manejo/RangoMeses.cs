using AppEventos.Escritura;
using AppEventos.Lectura;
using AppEventos.Properties;
using AppEventos.Tiempo;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEventos.Manejo
{
    public class RangoMeses : ManejadorRangos
    {
        private readonly IEscritor escritor;

        private readonly IOcurrencia ocurrencia;

        public RangoMeses(IEscritor escritor, IOcurrencia ocurrencia)
        {
            this.escritor = escritor;
            this.ocurrencia = ocurrencia;
        }

        protected override bool PersistirEvento(Lectura.Evento evento)
        {
            double _dRangoTiempo = ObtenerRangoTiempoPorMeses(evento.dtFecha);

            if (_dRangoTiempo >= 1)
            {
                string _cOcurrencia = ocurrencia.ObtenerOcurrencia(evento.dtFecha);

                string _cMensaje = ObtenerMensaje(evento.cNombre, _cOcurrencia, _dRangoTiempo);

                escritor.EscribirResultado(_cMensaje);

                return true;
            }
            else
            {
                return false;
            }

        }

        protected override string ObtenerMensaje(string cNombre, string cOcurrencia, double dRangoTiempo)
        {
            return cNombre + cOcurrencia + dRangoTiempo + Resources.meses;
        }

        private double ObtenerRangoTiempoPorMeses(DateTime dtFecha)
        {
            return Math.Round(Math.Abs((dtFecha - DateTime.Now).TotalDays) / 30.436875);
        }
    }
}

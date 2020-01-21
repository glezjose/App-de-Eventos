using System;
using System.Collections.Generic;
using System.Text;

namespace AppEventos.Tiempo
{
    public class Ocurrencia : IOcurrencia
    {
        public string ObtenerOcurrencia(DateTime dtFecha)
        {
            if (dtFecha < DateTime.Now)
            {
                return " ocurrió hace ";
            }
            else
            {
                return " ocurrirá dentro de ";
            }
        }
    }
}

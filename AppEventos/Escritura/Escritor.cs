using System;
using System.Collections.Generic;
using System.Text;

namespace AppEventos.Escritura
{
    public class Escritor : IEscritor
    {
        public void EscribirResultado(string cMensaje)
        {
            Console.WriteLine(cMensaje);
        }
    }
}

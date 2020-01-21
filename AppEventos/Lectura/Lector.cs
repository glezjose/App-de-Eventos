using AppEventos.Conversion;
using System;
using System.Collections.Generic;
using System.IO;

namespace AppEventos.Lectura
{
    public class Lector : ILector
    {
        private readonly IConvertidor convertidor;
        private readonly string cRuta;

        public Lector(IConvertidor convertidor, string cRuta)
        {
            this.convertidor = convertidor;
            this.cRuta = cRuta ?? throw new ArgumentNullException(nameof(cRuta)); ;
        }

        public IReadOnlyList<Evento> LeerArchivo()
        {
            List<Evento> _lstEventos = new List<Evento>();
            try
            {
                using (StreamReader sr = new StreamReader(cRuta))
                {
                    string _cLinea;
                    while ((_cLinea = sr.ReadLine()) != null)
                    {
                        Evento _evento = convertidor.ConvertirEvento(_cLinea);

                        AgregarEventoLista(_evento, _lstEventos);
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("La ruta especificada no se encuentra o no existe.");
            }

            return _lstEventos;
        }

        private void AgregarEventoLista(Evento evento, List<Evento> lstEventos)
        {
            lstEventos.Add(evento);
        }
    }
}


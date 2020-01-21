using AppEventos.Fabrica;
using AppEventos.Lectura;
using AppEventos.Manejo;
using System.Collections.Generic;

namespace AppEventos.Procesamiento
{
    public class Procesador : IProcesador
    {
        private readonly IManejoTiemposFactory manejoTiemposFactory;
        private readonly ILector lector;

        public Procesador(IManejoTiemposFactory manejoTiemposFactory, ILector lector)
        {
            this.manejoTiemposFactory = manejoTiemposFactory;
            this.lector = lector;
        }

        public void ProcesarEventos()
        {
           IEnumerable<Lectura.Evento> _lstEventos = lector.LeerArchivo();

            foreach (Lectura.Evento _evento in _lstEventos)
            {
                IManejadorRangos _manejador = manejoTiemposFactory.crearManejador();

                EvaluarPersistenciaEvento(_manejador, _evento);
            }
        }

        private void EvaluarPersistenciaEvento(IManejadorRangos manejador, Lectura.Evento evento)
        {
            manejador.EvaluarEvento(evento);
        }
    }
}

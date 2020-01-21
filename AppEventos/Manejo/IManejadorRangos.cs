using AppEventos.Lectura;

namespace AppEventos.Manejo
{
    public interface IManejadorRangos
    {
        void AsignarSiguiente(IManejadorRangos manejador);

        void EvaluarEvento(Lectura.Evento evento);
    }
}

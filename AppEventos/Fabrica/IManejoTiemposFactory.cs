using AppEventos.Manejo;

namespace AppEventos.Fabrica
{
    public interface IManejoTiemposFactory
    {
        IManejadorRangos crearManejador();
    }
}

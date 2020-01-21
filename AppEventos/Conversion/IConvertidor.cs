using AppEventos.Lectura;

namespace AppEventos.Conversion
{
    public interface IConvertidor
    {
        Lectura.Evento ConvertirEvento(string cEvento);
    }
}

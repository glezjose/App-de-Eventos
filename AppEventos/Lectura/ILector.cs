using System.Collections.Generic;

namespace AppEventos.Lectura
{
    public interface ILector
    {
        IReadOnlyList<Evento> LeerArchivo();
    }
}

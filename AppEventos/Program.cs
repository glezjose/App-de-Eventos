using AppEventos.Conversion;
using AppEventos.Escritura;
using AppEventos.Evento;
using AppEventos.Fabrica;
using AppEventos.Lectura;
using AppEventos.Modelo;
using AppEventos.Procesamiento;
using AppEventos.Properties;
using AppEventos.Tiempo;
using System;

namespace AppEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            EventoContext ctx = new EventoContext();
            EventoService es = new EventoService(ctx);
            IConvertidor _Convertidor = new Convertidor(es);
            ILector _Lector = new Lector(_Convertidor, "../../../Resources/archivo.txt");

            IEscritor _Escritor = new Escritor();
            IOcurrencia _Ocurrencia = new Ocurrencia();
            IManejoTiemposFactory _ManejoTiemposFactory = new ManejoTiemposFactory(_Escritor, _Ocurrencia);

            IProcesador _Procesador = new Procesador(_ManejoTiemposFactory, _Lector);
            _Procesador.ProcesarEventos();

            Console.ReadLine();
        }
    }
}

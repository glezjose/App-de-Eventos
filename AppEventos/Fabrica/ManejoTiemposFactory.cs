using AppEventos.Escritura;
using AppEventos.Manejo;
using AppEventos.Tiempo;

namespace AppEventos.Fabrica
{
    public class ManejoTiemposFactory : IManejoTiemposFactory
    {
        private readonly IEscritor escritor;
        private readonly IOcurrencia ocurrencia;

        public ManejoTiemposFactory(IEscritor escritor, IOcurrencia ocurrencia)
        {
            this.escritor = escritor;
            this.ocurrencia = ocurrencia;
        }

        public IManejadorRangos crearManejador()
        {
            IManejadorRangos _minutos = new RangoMinutos(escritor, ocurrencia);
            IManejadorRangos _horas = new RangoHoras(escritor, ocurrencia);
            IManejadorRangos _dias = new RangoDias(escritor, ocurrencia);
            IManejadorRangos _meses = new RangoMeses(escritor, ocurrencia);

            AsignarSiguienteManejador(_minutos, _horas);
            AsignarSiguienteManejador(_horas, _dias);
            AsignarSiguienteManejador(_dias, _meses);

            return _minutos;
        }

        private void AsignarSiguienteManejador(IManejadorRangos anterior, IManejadorRangos siguiente)
        {
            anterior.AsignarSiguiente(siguiente);
        }
    }
}

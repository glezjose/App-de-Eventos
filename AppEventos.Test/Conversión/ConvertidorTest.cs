using AppEventos.Conversion;
using AppEventos.Evento;
using AppEventos.Lectura;
using AppEventos.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AppEventos.Test.Conversión
{
    [TestClass]
    public class ConvertidorTest
    {
        private Convertidor convertidor;

        [TestInitialize]
        public void Configurar()
        {
            EventoContext ctx = new EventoContext();
            EventoService eventoService = new EventoService(ctx);
            convertidor = new Convertidor(eventoService);
        }

        [TestMethod]
        public void ConvertidorTest_TirarExcepcionFueraRango_ConvertirEvento()
        {
            //Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => convertidor.ConvertirEvento("8"));

        }

        [TestMethod]
        public void ConvertidorTest_RegresaEvento_ConvertirEvento()
        {
            //Arrange
            string _cEvento = "Hanal Pixán, 01/10/2020";
            Lectura.Evento _eventoEsperado = new Lectura.Evento { cNombre = "Hanal Pixán", dtFecha = DateTime.Parse("01/10/2020") };

            //Act
            Lectura.Evento _eventoResultado = convertidor.ConvertirEvento(_cEvento);

            //Assert
            Assert.AreEqual(_eventoEsperado.cNombre, _eventoResultado.cNombre);
            Assert.AreEqual(_eventoEsperado.dtFecha, _eventoResultado.dtFecha);
        }
    }
}

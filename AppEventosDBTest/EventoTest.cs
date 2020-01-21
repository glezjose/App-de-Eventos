using AppEventos.Evento;
using AppEventos.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppEventosDBTest
{
    [TestClass]
    public class EventoTest: BaseContextTest
    {
        [TestMethod]
        public void InsertarEventoMetodo_Deberia_InsertarNuevoElemento()
        {
            EventoService _EventoService = new EventoService(ctx);
            Evento _evento = new Evento { Nombre = "Halloween", Fecha = DateTime.Parse("31/10/2020")};

            _EventoService.InsertarEvento(_evento);

            List<Evento> _lstEvento = _EventoService.ObtenerEventosPorNombre("Halloween");
            Assert.IsTrue(_lstEvento.Any());
        }
    }
}

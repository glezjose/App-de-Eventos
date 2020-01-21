using AppEventos.Conversion;
using AppEventos.Lectura;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AppEventos.Test
{
    [TestClass]
    public class LectorTest
    {

        [TestMethod]
        public void LectorTest_TirarExcepcionRuta_LeerArchivo()
        {
            //Arrange
            Mock<IConvertidor> convertidor = new Mock<IConvertidor>();
            Lector lector = new Lector(convertidor.Object, "../Archivo/archivo.txt");

            //Assert
            Assert.ThrowsException<DirectoryNotFoundException>(() => lector.LeerArchivo());
        }

        [TestMethod]
        public void LectorTest_ArchivoNulo_LeerArchivo()
        {
            //Arrange
            Mock<IConvertidor> convertidor = new Mock<IConvertidor>();
            Lector lector = new Lector(convertidor.Object, "../../../../AppEventos/Archivo/archivoNulo.txt");

            //Act
            IReadOnlyList<Lectura.Evento> _lstEventos = lector.LeerArchivo();

            //Assert
            Assert.IsFalse(_lstEventos.Any());
        }
    }
}

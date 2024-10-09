using AutoBogus;
using Bogus;
using H_API.Services.Interfaces;
using H_API.Services.Services;
using HARMONIA.Core.Interfaces;
using HARMONIA.Domain.DTOs.Telemetria;
using HARMONIA.Domain.Entidades;
using HARMONIA.Domain.Enums;
using HARMONIA.Tests.Utilidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HARMONIA.Tests.Servicios
{
    [TestClass]
    public class TellemetryServiceTests
    {
        Mock<IDbService> mockDbService = new Mock<IDbService>();
        ITellemetryService tellemetryService;

        private void seedTestingContext() {
            tellemetryService = new TellemetryService(mockDbService.Object);
        }

        [TestMethod]
        public void InsertHumedalData_Ok() {
            //Arrange 
            seedTestingContext();

            TellemetryPost tellemetryPost = new AutoFaker<TellemetryPost>().Generate();
            HumedalData humedalData = new HumedalData(tellemetryPost);

            mockDbService.Setup(db => db.InsertDocument(DataBaseContainers.Telemetria, It.IsAny<HumedalData>()))
                .Returns(() => {
                    humedalData.Id = Guid.NewGuid().ToString();
                    return humedalData;
                    });

            //Act
            string postId = tellemetryService.InsertHumedalData(tellemetryPost);

            //Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(postId));
            Assert.AreEqual(humedalData.Id, postId);

            mockDbService.Verify(db => db.InsertDocument(DataBaseContainers.Telemetria, It.Is<HumedalData>(x => 
            x.Nivel == humedalData.Nivel
            && x.Turbulencia == humedalData.Turbulencia
            && x.Ph == humedalData.Ph
            && x.Temperatura == humedalData.Temperatura)), Times.Once);
        }
    }
}

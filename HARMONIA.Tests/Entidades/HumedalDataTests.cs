using Bogus;
using HARMONIA.Domain.DTOs.Telemetria;
using HARMONIA.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HARMONIA.Tests.Entidades
{
    [TestClass]
    public class HumedalDataTests
    {
        Faker Faker = new Faker();
        
        [TestMethod]
        public void CrearHumedalData() {
            //Arrange 
            TellemetryPost post = new TellemetryPost
            {
                Nivel = Faker.Random.Double(0, 16),
                AlturaNivelAgua = Faker.Random.Double(0, 16), 
                Flujo = Faker.Random.Double(0, 16), 
                Humedad = Faker.Random.Double(0, 16), 
                Temperatura = Faker.Random.Double(0,45),
                SolidosDisueltos = Faker.Random.Double(0,45),
                Turbidez = Faker.Random.Double(0,1024),
                Ph = Faker.Random.Double(0, 16)
            };
            
            //Act
            DateTime now = DateTime.Now;
            HumedalData data = new HumedalData(post);

            //Assert
            Assert.AreEqual(post.Nivel, data.Nivel);
            Assert.AreEqual(post.AlturaNivelAgua, data.AlturaNivelAgua);
            Assert.AreEqual(post.Flujo, data.Flujo);
            Assert.AreEqual(post.Humedad, data.Humedad);
            Assert.AreEqual(post.Temperatura, data.Temperatura);
            Assert.AreEqual(post.SolidosDisueltos, data.SolidosDisueltos);
            Assert.AreEqual(post.Turbidez, data.Turbidez);
            Assert.AreEqual(post.Ph, data.Ph);

            Assert.IsFalse(data.TimeStamp == default);
            Assert.AreEqual(now.Year,data.TimeStamp.Year);
            Assert.AreEqual(now.Month,data.TimeStamp.Month);
            Assert.AreEqual(now.Day,data.TimeStamp.Day);
            Assert.AreEqual(now.Hour,data.TimeStamp.Hour);
        }
    }
}

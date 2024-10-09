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
                Ph = Faker.Random.Double(0, 16),
                Temperatura = Faker.Random.Double(0,45),
                Turbulencia = Faker.Random.Double(0,1024)
            };
            
            //Act
            DateTime now = DateTime.Now;
            HumedalData data = new HumedalData(post);

            //Assert
            Assert.AreEqual(post.Nivel, data.Nivel);
            Assert.AreEqual(post.Ph, data.Ph);
            Assert.AreEqual(post.Temperatura, data.Temperatura);
            Assert.AreEqual(post.Turbulencia, data.Turbulencia);

            Assert.IsFalse(data.TimeStamp == default);
            Assert.AreEqual(now.Year,data.TimeStamp.Year);
            Assert.AreEqual(now.Month,data.TimeStamp.Month);
            Assert.AreEqual(now.Day,data.TimeStamp.Day);
            Assert.AreEqual(now.Hour,data.TimeStamp.Hour);
        }
    }
}

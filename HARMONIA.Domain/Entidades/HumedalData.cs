using HARMONIA.Domain.DTOs.Telemetria;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HARMONIA.Domain.Entidades
{
    public class HumedalData
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public double Nivel { get; set; }
        public double AlturaNivelAgua { get; set; }
        public double Flujo { get; set; }
        public double Humedad { get; set; }
        public double Temperatura { get; set; }
        public double SolidosDisueltos { get; set; }
        public double Turbidez { get; set; }
        public double Ph { get; set; }
        public DateTime TimeStamp { get; set; }

        public HumedalData(TellemetryPost dto)
        {
            Nivel = dto.Nivel;
            AlturaNivelAgua = dto.AlturaNivelAgua;
            Flujo = dto.Flujo;
            Humedad = dto.Humedad;
            Temperatura = dto.Temperatura;
            SolidosDisueltos = dto.SolidosDisueltos;
            Turbidez = dto.Turbidez;
            Ph = dto.Ph;

            TimeStamp = DateTime.UtcNow.AddHours(-6);
        }
    }
}

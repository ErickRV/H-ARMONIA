using HARMONIA.Domain.DTOs.Telemetria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HARMONIA.Domain.Entidades
{
    public class HumedalData
    {
        public string Id { get; set; }
        public double Nivel { get; set; }
        public double Turbulencia { get; set; }
        public double Ph { get; set; }
        public double Temperatura { get; set; }
        public DateTime TimeStamp { get; set; }

        public HumedalData(TellemetryPost dto)
        {
            this.Nivel = dto.Nivel;
            this.Turbulencia = dto.Turbulencia;
            this.Ph = dto.Ph;
            this.Temperatura = dto.Temperatura;

            TimeStamp = DateTime.Now;
        }
    }
}

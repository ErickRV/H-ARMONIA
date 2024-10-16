using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HARMONIA.Domain.DTOs.Telemetria
{
    public class TellemetryPost
    {
        public double Nivel { get; set; }
        public double AlturaNivelAgua { get; set; }
        public double Flujo { get; set; }
        public double Humedad { get; set; }
        public double Temperatura { get; set; }
        public double SolidosDisueltos { get; set; }
        public double Turbidez { get; set; }
        public double Ph { get; set; } //Pendiente...
    }
}

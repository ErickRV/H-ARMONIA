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
        public double Turbulencia { get; set; }
        public double Ph { get; set; }
        public double Temperatura { get; set; }
    }
}

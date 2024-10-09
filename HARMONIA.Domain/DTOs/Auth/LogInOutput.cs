using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HARMONIA.Domain.DTOs.Auth
{
    public class LogInOutput
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}

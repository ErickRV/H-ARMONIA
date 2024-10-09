using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HARMONIA.Tests.Utilidades
{
    public static class TestUtils
    {
        public static bool AreObjectsEqual(object obj1, object obj2)
        {
            if (JsonConvert.SerializeObject(obj1) == JsonConvert.SerializeObject(obj2))
                return true;
            else
                return false;
        }
    }
}

using assessment_server_side.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.Utils
{
    public static class UtilColor
    {
        public static List<Color> Colors = new List<Color>()
        {
            new Color(){Id = 1 , Name = "blau"},
            new Color(){Id = 2 , Name = "grün"},
            new Color(){Id = 3 , Name = "violett"},
            new Color(){Id = 4 , Name = "rot"},
            new Color(){Id = 5, Name = "gelb"},
            new Color(){Id = 6 , Name = "türkis"},
            new Color(){Id = 7 , Name = "weiß"}
        };
    }
}

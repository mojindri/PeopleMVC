using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.Models.Factory
{
    public class ColorFactory : IFactory<Color>

    {
        public Color Create()
        {
            return new Color();
        }
    }
}

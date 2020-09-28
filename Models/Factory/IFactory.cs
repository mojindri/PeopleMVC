using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.Models.Factory
{
    public interface IFactory<T>
    {
        public T Create();
    }
}

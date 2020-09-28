using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.CSVDataSource
{
    public interface IDataSource<T>
    {
        public IEnumerable<T> ReadAll();
        public bool WriteAll(IEnumerable<T> items);
    }
}

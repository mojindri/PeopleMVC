using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.Exceptions
{
    public enum DataSourceIsEmptyType { Database,CSV}
    public class DataSourceEmptyException : Exception
    {
        public DataSourceEmptyException(DataSourceIsEmptyType type):
            base(type==DataSourceIsEmptyType.CSV ? "CsvFile is empty": "there is no Data on Databae")
        {
            
        }
    }
}

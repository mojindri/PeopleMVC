using assessment_server_side.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.EntityDataSource
{
    public interface IPersonsContext
    { 
        public   DbSet<Color> Colors { get; set; }
        public   DbSet<Person> Persons { get; set; }
    }
}

using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.Models.Factory
{
    public class PersonFactory : IFactory<Person>
    {
        public Person Create()
        {
            return new Person();
        }
    }
}

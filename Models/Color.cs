using System;
using System.Collections.Generic;

namespace assessment_server_side.Models
{
    public partial class Color
    {
        public Color()
        {
            Persons = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace assessment_server_side.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public int? FavColourId { get; set; }

        public virtual Color FavColour { get; set; }
    }
}

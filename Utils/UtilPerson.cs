using assessment_server_side.Models;
using assessment_server_side.Models.Factory;
using assessment_server_side.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.utils
{
    public static class UtilPerson
    {
        private readonly static IFactory<Person> _personFact = new PersonFactory();
        public static Person FromString(string id, string name, string last, string post, string city, string favcolorid)
        {
            var person = _personFact.Create();
            person.Id = int.Parse(id);
            person.Lastname = last;
            person.Name = name;
            person.City = city;
            person.Zipcode = post;
            person.FavColourId = int.Parse(favcolorid);
            person.FavColour = UtilColor.Colors.FirstOrDefault(f => f.Id == person.FavColourId);
            return person;
        }
        public static string FromPerson(Person person)
        {
            return string.Format("\r\n{0}, {1}, {2} {3},{4}", person.Lastname, person.Name, person.Zipcode, person.City, person.FavColourId);
        }
    }
}

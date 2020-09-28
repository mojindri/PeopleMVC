using assessment_server_side.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.Controllers.Serializer
{

    internal class PersonJsonConverter
    {
        private Person _person;
        public PersonJsonConverter(Person person)
        {
            this._person = person;
        }
        [JsonProperty("id")]
        public int Id => _person.Id;
        [JsonProperty("name")]
        public string Name => _person.Name;

        [JsonProperty("lastname")]
        public string LastName => _person.Lastname;
        [JsonProperty("zipcode")]

        public string Zipcode => _person.Zipcode;
        [JsonProperty("city")]
        public string City => _person.City;
        [JsonProperty("color")]
        public string Color => _person.FavColour.Name.Trim();
    }
}

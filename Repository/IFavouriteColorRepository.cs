using assessment_server_side.Controllers;
using assessment_server_side.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.Repository
{
    public interface IFavouriteColorRepository
    {
        public IEnumerable<Person> GetPeople();

        public Person GetPerson(int id);

        public IEnumerable<Person> GetPeopleByColor(string colorId);
        bool SavePeople(IEnumerable<Person> people);
    }
}

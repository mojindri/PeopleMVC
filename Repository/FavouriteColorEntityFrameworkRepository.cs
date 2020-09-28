using assessment_server_side.EntityDataSource;
using assessment_server_side.Exceptions;
using assessment_server_side.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace assessment_server_side.Repository
{
    public partial class FavouriteColorEntityFrameworkRepository : IFavouriteColorRepository
    {
        private readonly PersonsContext _personsContext;
        public FavouriteColorEntityFrameworkRepository()
        {
            _personsContext = new PersonsContext();
        }
        public IEnumerable<Person> GetPeople()
        {
            EnsurePeopleExist();
            return _personsContext.Persons.Include(p => p.FavColour).ToList(); ;
        }

        private void EnsurePeopleExist()
        {
            if (_personsContext.Persons.Count() == 0)
                throw new PersonNotExistException();

        }

        public IEnumerable<Person> GetPeopleByColor(string colorname)
        {
            ColorValidation(colorname);
            return _personsContext.Persons.Include(p => p.FavColour).Where(c => c.FavColour.Name.ToLower() == colorname.ToLower()).ToList();
        }

        public Person GetPerson(int id)
        {
            PersonValidation(id);
            return _personsContext.Persons.FirstOrDefault(f => f.Id == id);
        }
        private bool PersonValidation(int personId)
        {
            if (!_personsContext.Persons.Any(f => f.Id == personId))
                throw new PersonNotExistException(personId);
            return true;
        }
        private bool ColorValidation(string colorname)
        {
            if (!_personsContext.Colors.Any(f => f.Name.ToLower().Equals(colorname.ToLower())))
                throw new ColorNotExistException(colorname);
            return true;
        }

        public bool SavePeople(IEnumerable<Person> people)
        {
            if (people.Count() == 0)
                throw new NoPeopleForUpdateException();
            if (people.Any(f => f.FavColourId == null))
                throw new ColorIsNullException();

            int idcounter = this._personsContext.Persons.OrderByDescending(f => f.Id).FirstOrDefault().Id + 1;
            foreach (var item in people)
            {
                item.Id = idcounter++;
                _personsContext.Persons.Add(item);
            }

            _personsContext.SaveChanges();
            return true;

        }

    }
}

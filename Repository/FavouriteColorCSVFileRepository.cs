using assessment_server_side.CSVDataSource;
using assessment_server_side.Exceptions;
using assessment_server_side.Models;
using assessment_server_side.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.Repository
{
    public class FavouriteColorCSVFileRepository : IFavouriteColorRepository
    {
        private readonly IDataSource<Person> _cSVFIleDataSource;

        public FavouriteColorCSVFileRepository()
        {
            _cSVFIleDataSource = new CSVFIleDataSource();
        }
        public IEnumerable<Person> GetPeople()
        {
            EnsurePeopleExist();
            return _cSVFIleDataSource.ReadAll();
        }

        public IEnumerable<Person> GetPeopleByColor(string colorname)
        {
            ColorValidation(colorname);
            var query = from p in _cSVFIleDataSource.ReadAll()
                        join c in UtilColor.Colors on p.FavColourId equals c.Id
                        where c.Name.ToLower() == colorname.ToLower()
                        select p;
            return query.ToList();
        }

        public Person GetPerson(int id)
        {
            var check = PersonValidation(id);
            return _cSVFIleDataSource.ReadAll().FirstOrDefault(p => p.Id == id);
        }


        private void EnsurePeopleExist()
        {
            if (_cSVFIleDataSource.ReadAll().Count() == 0)
                throw new PersonNotExistException();

        }

        private bool  PersonValidation(int personId)
        {
            if (!_cSVFIleDataSource.ReadAll().Any(f => f.Id == personId))
                throw new PersonNotExistException(personId);
            return true;
        }
        private bool ColorValidation(string colorname)
        {
            if (!UtilColor.Colors.Any(f => f.Name.ToLower().Equals(colorname.ToLower())))
                throw new ColorNotExistException(colorname);
            return true;
        }

        public bool SavePeople(IEnumerable<Person> people)
        {
            if (people.Count() == 0)
                throw new NoPeopleForUpdateException();
            if (people.Any(f => f.FavColourId == null))
                throw new ColorIsNullException();

            return _cSVFIleDataSource.WriteAll(people);
        }
    }
}

using assessment_server_side.Controllers.DTOs;
using assessment_server_side.Models;
using assessment_server_side.Utils;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment_server_side.Controllers.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {

            CreateMap<PersonSaveDTO, Person>().
                ForMember(up => up.FavColourId,opt => opt.MapFrom(f => UtilColor.Colors.FirstOrDefault(v => v.Name.ToLower().Equals(f.Color)).Id));
        }
    }
}

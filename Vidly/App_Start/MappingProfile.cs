using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //when we call this method automapper 
            //uses reflection to scan these types and scans their properties and maps them based on there names
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MovieGenre, GenreDto>();
            //Mapper.CreateMap<MovieDto, Movie>();

            //Dto to Domain
            Mapper.CreateMap<CustomerDto,Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto,Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());

        }
    };
}
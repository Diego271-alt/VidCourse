using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using AutoMapper;
using VidCourse.Dtos;
using VidCourse.Models;

namespace VidCourse.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            /*
             Definimos nuestros perfiles de mapeo
            en este caso vamos a necesitar dos tipos
            de customer a CustomerDto y de cutomerDto a customer
            Necesitamos mandar los parametros con los mismos nombres para que esto no genere
            ningun conflicto
            Tenemos que carharlos en Globac.asax


             
             */

            //soruce,target
            Mapper.CreateMap<Customer, CustomerDto>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();


            //Dto to domain

            Mapper.CreateMap<CustomerDto, Customer>()
    .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }

    }
}
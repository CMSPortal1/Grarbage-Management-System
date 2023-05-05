using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Garbage.Common;
using Garbage.Common.DTO;
using Garbage.EF;

namespace Garbage.API.App_Start
{
    public class MappingProfile
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {

                config.CreateMap<signup, UserDTO> ().ReverseMap();
            });
        }
    }
}
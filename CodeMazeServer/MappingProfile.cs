﻿using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
namespace CodeMazeServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Programs, ProgramDTO>();
            CreateMap<ProgramForCreationDto, Programs>();
        }
    }
}

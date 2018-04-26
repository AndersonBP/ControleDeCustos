using AutoMapper;
using ControleCustos.Api.Database.Entity;
using ControleCustos.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleCustos.Api.Infra.CrossCutting.IoC.Mappers
{
	internal class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<FuncionarioEntity, Funcionario>().ReverseMap();
			CreateMap<DepartamentoEntity, Departamento>().ReverseMap();


			CreateMap<Funcionario, FuncionarioEntity>().ReverseMap();
			CreateMap<Departamento, DepartamentoEntity>().ReverseMap();

		}
	}
}


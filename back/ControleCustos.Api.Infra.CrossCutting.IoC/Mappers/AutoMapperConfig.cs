using AutoMapper;
using ControleCustos.Api.Infra.CrossCutting.IoC.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleCustos.Api.Infra.CrossCutting.IoC.Mappers
{
	public static class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.Initialize(x => {
				x.AddProfile<MappingProfile>();
			});
		}
	}
}

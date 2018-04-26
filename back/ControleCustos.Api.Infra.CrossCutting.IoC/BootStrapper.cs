using ControleCustos.Api.Business.Manager;
using ControleCustos.Api.Database;
using ControleCustos.Api.Database.Repository;
using ControleCustos.Api.Domain.Interfaces.Manager;
using ControleCustos.Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Infra.CrossCutting.IoC
{
	public static class BootStrapper
	{
		public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<Context>();
			services.AddDbContext<Context>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddScoped<IFuncionarioManager, FuncionarioManager>();
			services.AddScoped<IDepartamentoManager, DepartamentoManager>();
			services.AddScoped<IMovimentacaoManager, MovimentacaoManager>();

			services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
			services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
			services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();

		}
	}
}

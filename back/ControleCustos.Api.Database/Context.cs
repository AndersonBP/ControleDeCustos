using ControleCustos.Api.Database.Entity;
using ControleCustos.Api.Database.ModelBuilders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ControleCustos.Api.Database
{
	public class Context :  DbContext
	{
		//https://www.devmedia.com.br/entity-framework-core-criando-bases-de-dados-com-migrations/36776
		//https://docs.microsoft.com/pt-br/ef/core/get-started/aspnetcore/new-db
		public Context()
		{ }

		public Context(DbContextOptions<Context> options)
			: base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				IConfigurationRoot configuration = new ConfigurationBuilder()
				   .SetBasePath(Directory.GetCurrentDirectory())
				   .AddJsonFile("appsettings.json")
				   .Build();
				var connectionString = configuration.GetConnectionString("DefaultConnection");
				optionsBuilder.UseSqlServer(connectionString);
			}
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.ForSqlServerUseIdentityColumns();
			modelBuilder.HasDefaultSchema("ControleCustosDB");
			FuncionarioModelBuilder.Configure(modelBuilder);
			DepartamentoModelBuilder.Configure(modelBuilder);
			MovimentacaoModelBuilder.Configure(modelBuilder);
		}


		public DbSet<FuncionarioEntity> Funcionarios { get; set; }
        public DbSet<DepartamentoEntity> Departamentos{ get; set; }
        public DbSet<MovimentacaoEntity> Movimentacoes{ get; set; }
	}
}

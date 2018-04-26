using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ControleCustos.Api.Database
{
	//https://www.benday.com/2017/12/19/ef-core-2-0-migrations-without-hard-coded-connection-strings/
	//https://codingblast.com/entityframework-core-idesigntimedbcontextfactory/
	public abstract class DesignTimeDbContextFactoryBase<TContext> :
		IDesignTimeDbContextFactory<TContext> where TContext : DbContext
	{
		public TContext CreateDbContext(string[] args)
		{
			return Create(
				Directory.GetCurrentDirectory(),
				Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
		}
		protected abstract TContext CreateNewInstance(
			DbContextOptions<TContext> options);

		public TContext Create()
		{
			var environmentName =
				Environment.GetEnvironmentVariable(
					"ASPNETCORE_ENVIRONMENT");

			var basePath = AppDomain.CurrentDomain.BaseDirectory;

			return Create(basePath, environmentName);
		}

		private TContext Create(string basePath, string environmentName)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{environmentName}.json", true)
				.Build();


			var connstr = @"Data Source=localhost;Initial Catalog=ControleCustosDB;Integrated Security=True";//config.GetConnectionString("default");

			if (String.IsNullOrWhiteSpace(connstr) == true)
			{
				throw new InvalidOperationException(
					"Could not find a connection string named 'default'.");
			}
			else
			{
				return Create(connstr);
			}
		}

		private TContext Create(string connectionString)
		{
			if (string.IsNullOrEmpty(connectionString))
				throw new ArgumentException(
			 $"{nameof(connectionString)} is null or empty.",
			 nameof(connectionString));

			var optionsBuilder =
				 new DbContextOptionsBuilder<TContext>();

			Console.WriteLine(
				"MyDesignTimeDbContextFactory.Create(string): Connection string: {0}",
				connectionString);

			optionsBuilder.UseSqlServer(connectionString);

			DbContextOptions<TContext> options = optionsBuilder.Options;

			return CreateNewInstance(options);
		}
	}

}

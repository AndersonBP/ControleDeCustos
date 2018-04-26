using System;
using System.Collections.Generic;
using System.Text;
using ControleCustos.Api.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace ControleCustos.Api.Database.ModelBuilders
{
	public class FuncionarioModelBuilder
	{
		public static void Configure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<FuncionarioEntity>(etd =>
			 {
				 etd.ToTable("Funcionario");
				 etd.HasKey(c => c.Codigo).HasName("CodigoFuncionario");
				 etd.Property(c => c.Codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();
				 etd.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(200);
				 etd.HasOne(c => c.Departamento).WithMany(p => p.Funcionarios);
			 });
		}
	}
}

using ControleCustos.Api.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Database.ModelBuilders
{
    public class DepartamentoModelBuilder
    {
		public static void Configure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DepartamentoEntity>(etd =>
			{
				etd.ToTable("Departamento");
				etd.HasKey(c => c.Codigo).HasName("CodigoDepartamento");
				etd.Property(c => c.Codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();
				etd.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(100);
			});
		}
	}
}

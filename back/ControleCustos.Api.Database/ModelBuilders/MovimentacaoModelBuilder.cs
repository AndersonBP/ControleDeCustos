using ControleCustos.Api.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Database.ModelBuilders
{
    public class MovimentacaoModelBuilder
    {
		public static void Configure(ModelBuilder modelBuilder)
		{


			modelBuilder.Entity<MovimentacaoEntity>(etd =>
			{
				etd.ToTable("Movimentacao");
				etd.HasKey(c => c.Codigo).HasName("CodigoMovimentacao");
				etd.Property(c => c.Codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();
				etd.Property(c => c.Descricao).HasColumnName("Descricao").HasMaxLength(500);
				etd.Property(c => c.Valor).HasColumnName("Valor").HasColumnType("decimal(18,2)");
				etd.HasOne(c => c.Funcionario).WithMany(p => p.Movimentacoes);

			});
		}
	}
}

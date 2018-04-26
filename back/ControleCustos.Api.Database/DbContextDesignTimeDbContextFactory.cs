using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Database
{
	public class DbContextDesignTimeDbContextFactory :
		DesignTimeDbContextFactoryBase<Context>
	{
		protected override Context CreateNewInstance(
			DbContextOptions<Context> options)
		{
			return new Context(options);
		}
	}
}

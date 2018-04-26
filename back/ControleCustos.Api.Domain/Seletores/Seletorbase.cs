using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Domain.Seletores
{
	public enum OrderBy { ASC, DESC }

	public abstract class SeletorBase 
	{

		public SeletorBase()
		{
			this.Codigo = -1;
			this.OrderBy = "Codigo";
			this.Pagina = 1;
			this.RegistroPorPagina = 10;
			this.OrderByOrder = Seletores.OrderBy.ASC;
		}

		public int Codigo { get; set; }

		public int Pagina { get; set; }

		public int RegistroPorPagina { get; set; }

		public string OrderBy { get; set; }

		public OrderBy OrderByOrder { get; set; }

	}
}

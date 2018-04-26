using ControleCustos.Api.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Domain.Entities
{
	public class Movimentacao : DomainBase
	{
		public Funcionario Funcionario { get; set; }
		public string Descricao { get; set; }
		public decimal valor { get; set; }
	}
}

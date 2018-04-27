using ControleCustos.Api.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Domain.Entities
{
    public class Funcionario: DomainBase
	{
		public string Nome { get; set; }
		public int DepartamentoCodigo { get; set; }

		public Departamento Departamento { get; set; }
		public IEnumerable<Movimentacao> Movimentacoes { get; set; }
	}
}

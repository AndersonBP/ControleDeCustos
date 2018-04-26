using ControleCustos.Api.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Domain.Entities
{
    public class Departamento:DomainBase
    {
		public string Nome { get; set; }
		public IList<Funcionario> Funcionarios { get; set; }
	}
}

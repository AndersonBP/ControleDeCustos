using ControleCustos.Api.Database.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Database.Entity
{
    public class DepartamentoEntity : EntityBase
    {
		public string Nome { get; set; }
		public IList<FuncionarioEntity> Funcionarios { get; set; }
	}
}

using ControleCustos.Api.Database.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Database.Entity
{
    public class FuncionarioEntity: EntityBase
	{
		public string Nome { get; set; }
		public int DepartamentoCodigo { get; set; }
		public DepartamentoEntity Departamento { get; set; }
		public IEnumerable<MovimentacaoEntity> Movimentacoes { get; set; }
	}
}

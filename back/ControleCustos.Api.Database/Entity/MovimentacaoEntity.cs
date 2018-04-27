using ControleCustos.Api.Database.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Database.Entity
{
    public class MovimentacaoEntity:EntityBase
    {
		public FuncionarioEntity Funcionario { get; set; }
		public string Descricao { get; set; }
		public int FuncionarioCodigo { get; set; }
		public decimal Valor { get; set; }
	}
}

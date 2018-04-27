using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Domain.Seletores
{
    public class MovimentacaoSeletor:SeletorBase
    {
		public int FuncionarioCodigo { get; set; }
		public string Descricao { get; set; }
	}
}

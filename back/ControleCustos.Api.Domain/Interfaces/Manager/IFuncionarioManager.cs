using ControleCustos.Api.Domain.Entities;
using ControleCustos.Api.Domain.Interfaces.Manager.Base;
using ControleCustos.Api.Domain.Seletores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Domain.Interfaces.Manager
{
    public interface IFuncionarioManager: IManager<Funcionario, FuncionarioSeletor>
	{
    }
}

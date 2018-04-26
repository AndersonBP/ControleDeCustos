using ControleCustos.Api.Domain.Entities;
using ControleCustos.Api.Domain.Interfaces.Repository.Base;
using ControleCustos.Api.Domain.Seletores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Domain.Interfaces.Repository
{
    public interface IMovimentacaoRepository: IRepositoryBase<Movimentacao, MovimentacaoSeletor>
	{
    }
}

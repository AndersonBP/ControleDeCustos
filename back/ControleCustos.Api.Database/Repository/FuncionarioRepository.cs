using ControleCustos.Api.Database.Entity;
using ControleCustos.Api.Database.Repository.Abstract;
using ControleCustos.Api.Domain.Entities;
using ControleCustos.Api.Domain.Interfaces.Repository;
using ControleCustos.Api.Domain.Seletores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleCustos.Api.Database.Repository
{
    public class FuncionarioRepository : RepositoryBase<FuncionarioEntity, Funcionario, FuncionarioSeletor>, IFuncionarioRepository
	{
		public override IQueryable<FuncionarioEntity> CreateParameters(FuncionarioSeletor seletor, IQueryable<FuncionarioEntity> query)
		{
			return query = seletor.Codigo > 0 ? query.Where(x => x.Codigo == seletor.Codigo) : query;
		}
	}
}

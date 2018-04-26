using ControleCustos.Api.Database.Entity;
using ControleCustos.Api.Database.Repository.Abstract;
using ControleCustos.Api.Domain.Entities;
using ControleCustos.Api.Domain.Interfaces.Repository;
using ControleCustos.Api.Domain.Seletores;
using System.Linq;

namespace ControleCustos.Api.Database.Repository
{
    public class MovimentacaoRepository: RepositoryBase<MovimentacaoEntity, Movimentacao, MovimentacaoSeletor>, IMovimentacaoRepository
	{
		public override IQueryable<MovimentacaoEntity> CreateParameters(MovimentacaoSeletor seletor, IQueryable<MovimentacaoEntity> query)
		{
			return query = seletor.Codigo > 0 ? query.Where(x => x.Codigo == seletor.Codigo) : query;
		}
	}
}

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
			 query = seletor.Codigo > 0 ? query.Where(x => x.Codigo == seletor.Codigo) : query;

			query = seletor.FuncionarioCodigo > 0 ? query.Where(x => x.FuncionarioCodigo == seletor.FuncionarioCodigo) : query;

			query = !string.IsNullOrEmpty(seletor.Descricao)? query.Where(x => x.Descricao.Contains(seletor.Descricao)) : query;


			return query;
		}
	}
}

using ControleCustos.Api.Domain.Entities.Base;
using ControleCustos.Api.Domain.Seletores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ControleCustos.Api.Domain.Interfaces.Repository.Base
{
    public interface IRepositoryBase<TDomain, TSeletor>
		where TDomain : DomainBase
		where TSeletor : SeletorBase
	{
		TDomain Insert(TDomain obj);
        TDomain InsertWithSave(TDomain obj);

		TDomain Update(TDomain obj);

        void Delete(TDomain obj);

        IQueryable<TDomain> Get();

		List<TDomain> GetList(TSeletor seletor);

		int TotalRows(TSeletor seletor);

		bool Exist(Expression<Func<object, bool>> expression);

        void Save();
    }
}

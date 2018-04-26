using ControleCustos.Api.Domain.Entities.Base;
using ControleCustos.Api.Domain.Seletores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Domain.Interfaces.Manager.Base
{
	public interface IManager<TManager, TSeletor>
	   where TManager : DomainBase
	   where TSeletor : SeletorBase
	{
		TManager Get(int id);

		TManager Save(TManager obj);

		TManager Insert(TManager obj);

		List<TManager> GetList(TSeletor seletor);

		int TotalRows(TSeletor seletor);

		List<TManager> GetAll();
	}
}

using ControleCustos.Api.Business.Manager.Abstract;
using ControleCustos.Api.Domain.Entities;
using ControleCustos.Api.Domain.Interfaces.Manager;
using ControleCustos.Api.Domain.Interfaces.Repository;
using ControleCustos.Api.Domain.Seletores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Business.Manager
{
    public class MovimentacaoManager : ManagerBase, IMovimentacaoManager
	{
		IMovimentacaoRepository repository;

		public MovimentacaoManager(IMovimentacaoRepository repository)
		{
			this.repository = repository;
		}
		public Movimentacao Get(int id)
		{
			throw new NotImplementedException();
		}

		public List<Movimentacao> GetAll()
		{
			return this.repository.GetList(new MovimentacaoSeletor() { });
		}

		public List<Movimentacao> GetList(MovimentacaoSeletor seletor)
		{
			throw new NotImplementedException();
		}

		public Movimentacao Insert(Movimentacao obj)
		{
			throw new NotImplementedException();
		}

		public Movimentacao Save(Movimentacao obj)
		{
			if (obj.Codigo > 0)
				return this.repository.Update(obj);

			return this.repository.Insert(obj);
		}

		public int TotalRows(MovimentacaoSeletor seletor)
		{
			throw new NotImplementedException();
		}
	}
}

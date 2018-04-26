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
	public class FuncionarioManager : ManagerBase, IFuncionarioManager
	{
		IFuncionarioRepository repository;

		public FuncionarioManager(IFuncionarioRepository repository)
		{
			this.repository = repository;
		}
		public Funcionario Get(int id)
		{
			throw new NotImplementedException();
		}

		public List<Funcionario> GetAll()
		{
			return this.repository.GetList(new FuncionarioSeletor() { });
		}

		public List<Funcionario> GetList(FuncionarioSeletor seletor)
		{
			throw new NotImplementedException();
		}

		public Funcionario Insert(Funcionario obj)
		{
			throw new NotImplementedException();
		}

		public Funcionario Save(Funcionario obj)
		{
			if(obj.Codigo>0)
			return this.repository.Update(obj);

			return this.repository.Insert(obj);
		}

		public int TotalRows(FuncionarioSeletor seletor)
		{
			throw new NotImplementedException();
		}
	}
}

﻿using ControleCustos.Api.Business.Manager.Abstract;
using ControleCustos.Api.Domain.Entities;
using ControleCustos.Api.Domain.Interfaces.Manager;
using ControleCustos.Api.Domain.Interfaces.Repository;
using ControleCustos.Api.Domain.Seletores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleCustos.Api.Business.Manager
{
	public class DepartamentoManager : ManagerBase, IDepartamentoManager
	{
		IDepartamentoRepository repository;

		public DepartamentoManager(IDepartamentoRepository repository)
		{
			this.repository = repository;
		}
		public Departamento Get(int id)
		{
			throw new NotImplementedException();
		}

		public List<Departamento> GetAll()
		{
			return this.repository.GetList(new DepartamentoSeletor() { });
		}

		public List<Departamento> GetList(DepartamentoSeletor seletor)
		{
			throw new NotImplementedException();
		}

		public Departamento Insert(Departamento obj)
		{
			throw new NotImplementedException();
		}

		public Departamento Save(Departamento obj)
		{
			if (obj.Codigo > 0)
				return this.repository.Update(obj);

			return this.repository.Insert(obj);
		}

		public int TotalRows(DepartamentoSeletor seletor)
		{
			throw new NotImplementedException();
		}
	}
}

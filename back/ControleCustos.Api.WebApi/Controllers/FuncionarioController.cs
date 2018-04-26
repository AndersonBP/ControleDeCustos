using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ControleCustos.Api.WebApi.ViewModels;
using AutoMapper;
using ControleCustos.Api.Domain.Interfaces.Manager;
using ControleCustos.Api.Domain.Entities;

namespace ControleCustos.Api.WebApi.Controllers
{
	[Produces("application/json")]
	[Route("api/Funcionario")]
	public class FuncionarioController : Controller
	{
		private readonly IFuncionarioManager _manager;

		public FuncionarioController(IFuncionarioManager manager)
		{
			_manager = manager;
		}


		[HttpPost]
		[Route("list")]
		public ActionResult Get()
		{

			ActionResult result;
			var response = new ApiResponse<IEnumerable<Funcionario>>();
			try
			{
				var list = _manager.GetAll();
				if (list == null)
				{
					throw new Exception("lista nula");
				}
				else
				{
					response.Data = list;
					result = Ok(response);
				}

			}
			catch (Exception ex)
			{
				response.Error = new string[] { ex.InnerException?.Message ?? ex.Message };
				result = BadRequest(response);
			}

			return result;
		}

		[HttpPost]
		[Route("create")]
		public ActionResult Post([FromBody] Funcionario obj)
		{
			ActionResult result;
			var retorno = _manager.Save(obj);
			var response = new ApiResponse<Funcionario>();
			response.Data = retorno;
			result = Ok(response);
			return result;
		}
	}
}
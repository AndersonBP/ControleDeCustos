using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleCustos.Api.Domain.Entities;
using ControleCustos.Api.Domain.Interfaces.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleCustos.Api.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Movimentacao")]
    public class MovimentacaoController : Controller
    {
		private readonly IMovimentacaoManager _manager;

		public MovimentacaoController(IMovimentacaoManager manager)
		{
			_manager = manager;
		}


		[HttpPost]
		[Route("list")]
		public ActionResult Get()
		{

			ActionResult result;
			var response = new ApiResponse<IEnumerable<Movimentacao>>();
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
		public ActionResult Post([FromBody] Movimentacao obj)
		{
			ActionResult result;
			var retorno = _manager.Save(obj);
			var response = new ApiResponse<Movimentacao>();
			response.Data = retorno;
			result = Ok(response);
			return result;
		}
	}
}
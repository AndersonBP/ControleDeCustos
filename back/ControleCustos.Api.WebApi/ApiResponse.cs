using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleCustos.Api.WebApi
{
	public class ApiResponse<T>
	{
		public ApiResponse() { }
		public ApiResponse(T data, string[] error) { }

		public T Data { get; set; }
		public string[] Error { get; set; }
	}
}

using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TickTick.Api.Controllers
{

    [Route("/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ApiControllerBase:ControllerBase
	{
        private readonly IMediator mediatr;

        public ApiControllerBase(IMediator mediatr)
		{
            this.mediatr = mediatr;
        }

        public async Task<IActionResult> ExecuteRequest<T>(IRequest<T> request)
        {
            var response = new Response<T>();
            try
            {
                if (request == null) throw new ArgumentNullException("Request cqnnot be null.");
                var result = mediatr.Send(request);
                return StatusCode((int)response.Status, response);
            }
            catch (Exception ex)
            {
                var errors= new string[] {ex.Message, ex.InnerException!= null? ex.InnerException.Message:string.Empty };
                response.Errors = errors;
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return StatusCode((int)response.Status, response);

            }
        }
	}
}


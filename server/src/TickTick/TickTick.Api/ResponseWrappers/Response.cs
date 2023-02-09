using System;
using System.Net;

namespace TickTick.Api
{
	public class Response<T>
	{
		public T? Data { get; set; }
		public string[]? Errors { get; set; }
		public HttpStatusCode Status { get; set; }
		public string Message { get; set; }

        public Response(){ }

        public Response(T data) : this(data, HttpStatusCode.OK, null, string.Empty) { }

        public Response(T data, HttpStatusCode status) : this(data, status, null, string.Empty) { }

        public Response(T data, HttpStatusCode status, string message) : this(data, status, null, message) { }

        public Response(T data, HttpStatusCode status, string[] errors, string message)
		{
			this.Data = data;
			this.Status = status;
			this.Message = message;
			this.Errors = errors;
		}
	}
}


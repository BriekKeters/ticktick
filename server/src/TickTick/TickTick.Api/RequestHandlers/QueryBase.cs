﻿using System;
using MediatR;

namespace TickTick.Api.RequestHandlers
{
	public abstract class QueryBase<T>: IRequest<T>
	{
		public QueryBase()
		{
		}
	}
}


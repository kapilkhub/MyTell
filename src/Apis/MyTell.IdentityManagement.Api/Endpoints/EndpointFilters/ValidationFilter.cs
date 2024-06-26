﻿
using FluentValidation;

namespace MyTell.IdentityManagement.Api.Endpoints.EndpointFilters
{
	public class ValidationFilter<T> : IEndpointFilter
	{
		public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
		{
			var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();
            if (validator is not null)
            {
				var entity = context.Arguments.OfType<T>().FirstOrDefault(a => a?.GetType() == typeof(T));
				if (entity is not null)
				{
					var validation = await validator.ValidateAsync(entity);
					if (validation.IsValid)
					{
						return await next.Invoke(context);
					}
					return Results.ValidationProblem(validation.ToDictionary());
				}
				else 
				{
					return Results.Problem("Could not find the validator");
				}
            }
			return await next.Invoke(context);
		}
	}
}

using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IsubuSatis.Ortak
{
    public class IsubuValidationFilter<T> : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            var validator = context
                .HttpContext
                .RequestServices
                .GetService<IValidator<T>>();

            
            if (validator is null)
            {
                return await next(context);
            }

            var requestModel = context.Arguments.OfType<T>().FirstOrDefault();


            if (requestModel is null)
            {
                return await next(context);
            }

            var validateResult = await validator.ValidateAsync(requestModel);

            if (!validateResult.IsValid)
            {
                var hata = Results.ValidationProblem(validateResult.ToDictionary());
                return ServisSonuc<string>.Hata(new ServisHataDto
                {
                    Mesaj = "Doğrulama hataları",
                    //ValidationHatalari = ss.
                });
            }

            return await next(context);
        }
    }
}

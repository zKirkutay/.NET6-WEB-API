using CustomerOrder.Core.DTOs;
using CustomerOrder.Core.Models;
using CustomerOrder.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
namespace CustomerOrder.API.Filters
{
    public class NotFoundFilter<Entity, DTO> : IAsyncActionFilter where Entity : BaseEntity where DTO : class
    {
        private readonly IService<Entity, DTO> _service;

        public NotFoundFilter(IService<Entity, DTO> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next();
                return;
            }

            var id = (int)idValue;

            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity.Data)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponseDTO<NoContentDTO>.Fail((int)HttpStatusCode.NotFound, $"{typeof(Entity).Name}({id}) not found"));
        }
    }
}

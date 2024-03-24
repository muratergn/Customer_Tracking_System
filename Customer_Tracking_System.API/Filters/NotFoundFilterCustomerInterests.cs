using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core.Models;
using Customer_Tracking_System.Core.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Tracking_System.API.Filters
{
    public class NotFoundFilterCustomerInterests<T> : IAsyncActionFilter where T : CustomerInterests
    {

        private readonly IService<T> _service;

        public NotFoundFilterCustomerInterests(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));

        }
    }
}

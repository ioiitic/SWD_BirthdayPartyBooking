using BusinessObject.DTO.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace BirthdayPartyBooking.Filter
{
    public class CustomValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    );

                var response = new BadRequestObjectResult(new ServiceResponse<object>(false, "One or more validation errors occurred."));

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}

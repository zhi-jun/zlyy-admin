using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace ZLYY.Web.Filter
{
    public class ModelStateActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
            if (modelState.IsValid) return;
            var error = string.Empty;
            foreach (var state in modelState.Keys.Select(key => modelState[key]).Where(state => state.Errors.Any()))
            {
                error = state.Errors.First().ErrorMessage;
                break;
            }
            context.Result = new JsonResult(Result.Result.Failed(error));
        }
    }
}

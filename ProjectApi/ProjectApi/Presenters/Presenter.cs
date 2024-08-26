using Application.Results;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProjectApi.Presenters
{
    public static class Presenter
    {
        public static async Task<IActionResult> Do(Result result, HttpStatusCode statusCode)
        {

            if (result.Error.HasValue)
            {
                return result.Error.Value switch
                {
                    ErrorCode.NotFound => new NotFoundObjectResult(result),
                    ErrorCode.Business => new UnprocessableEntityObjectResult(result),
                    ErrorCode.Unauthorized => new UnauthorizedObjectResult(result),
                    ErrorCode.InternalError => new ObjectResult(result) { StatusCode = (int)HttpStatusCode.InternalServerError },
                    _ => new BadRequestObjectResult(result),
                };
            }
            else
            {
                return statusCode switch
                {
                    HttpStatusCode.Accepted => new AcceptedResult("", result.Data),
                    HttpStatusCode.OK => new OkObjectResult(result.Data),
                    HttpStatusCode.Created => new CreatedResult(string.Empty, result.Data),
                    HttpStatusCode.NoContent => new NoContentResult(),
                    _ => new OkResult()
                };
            }
        }


    }
}

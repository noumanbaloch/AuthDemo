using AuthDemo.Domain.Constants;
using AuthDemo.Domain.GenericResponse;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace AuthDemo.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _env;
    public ExceptionHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var payload = ex.InnerException != null ? ex.InnerException.ToString() : string.Empty;
            var response = _env.IsDevelopment() || _env.IsProduction() ?
                Domain.GenericResponse.GenericResponse<string>.Failure(payload, ex.Message, (int)HttpStatusCode.InternalServerError) :
                GenericResponse<string>.Failure(ApiResponseMessages.SOMETHING_WENT_WRONG, (int)HttpStatusCode.InternalServerError);

            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(response, settings);

            await context.Response.WriteAsync(json);
        }
    }
}

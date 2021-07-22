using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Post.Application.Common.Exceptions;
using Post.Application.Common.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Post.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };

            var result = string.Empty;

            switch (exception)
            {
                case MicroBlogException microBlogException:
                    code = microBlogException.StatusCode;
                    result = JsonConvert.SerializeObject(ServerResult.Exception(microBlogException.Message, microBlogException.Code), settings);
                    break;

                case ValidationException ex:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(ServerResult.Exception(ex.Message, "invalid_model", ex.Errors), settings);
                    break;

                case Exception ex:
                    code = HttpStatusCode.InternalServerError;
                    result = JsonConvert.SerializeObject(ServerResult.Exception("Something went wrong on the server!"), settings);
                    break;

                default:
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message }, settings);
            }

            return context.Response.WriteAsync(result);
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}

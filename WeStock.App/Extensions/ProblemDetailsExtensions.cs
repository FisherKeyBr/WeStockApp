using log4net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using WeStock.App.Exceptions;

namespace WeStock.App.Extensions
{
    public static class ProblemDetailsExtensions
    {
        public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if(exceptionHandlerFeature != null)
                    {
                        ILog log = LogManager.GetLogger(exceptionHandlerFeature!.Path);

                        var exception = exceptionHandlerFeature.Error;

                        ProblemDetails? problemDetails = null;

                        if(exception is ProblemDetailsException details)
                        {
                            problemDetails = GetProblemDetails(context, details.HttpStatus, details);
                        }else if(exception is BadHttpRequestException badHttpException)
                        {
                            problemDetails = GetProblemDetails(context, HttpStatusCode.BadRequest, badHttpException);
                        }
                        else if(exception is FluentValidation.ValidationException validationException)
                        {
                            problemDetails = GetProblemDetails(context, HttpStatusCode.Conflict, validationException);
                        }
                        else
                        {
                            problemDetails = GetProblemDetails(context, HttpStatusCode.InternalServerError, exception);
                        }

                        context.Response.StatusCode = problemDetails!.Status!.Value;
                        context.Response.ContentType = "application/problem+json";

                        log.Error(exception.Message, exception);

                        var json = JsonSerializer.Serialize(problemDetails);
                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }

        private static ProblemDetails? GetProblemDetails(
            HttpContext context, 
            HttpStatusCode status, 
            Exception details)
        {
            const string stackExtensionName = "Stack";

            var problemDetails = new ProblemDetails
            {
                Instance = context.Request.HttpContext.Request.Path,
                Title = ProblemDetailsException.GetHttpDescriptionBy(status),
                Status = (int)status,
                Detail = details.Message
            };

            problemDetails.Extensions.Add(stackExtensionName, details.ToString());

            return problemDetails;
        }
    }
}

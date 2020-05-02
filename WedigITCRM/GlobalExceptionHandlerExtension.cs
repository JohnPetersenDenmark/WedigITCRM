using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WedigITCRM.Utilities;

namespace WedigITCRM
{
    public static class GlobalExceptionHandlerExtension
    {
        //This method will globally handle logging unhandled execeptions.
        //It will respond json response for ajax calls that send the json accept header
        //otherwise it will redirect to an error page
        // public static void UseGlobalExceptionHandler(this IApplicationBuilder app , ILogger logger , string errorPagePath , bool respondWithJsonErrorDetails = false )
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app, IHostingEnvironment env, ILogger logger, string errorPagePath, bool respondWithJsonErrorDetails = false)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    //============================================================
                    //Log Exception
                    //============================================================

                   

                    var exception = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>().Error;

                    string errorDetails = $@"{exception.Message}
                                         {Environment.NewLine}
                                         {exception.StackTrace}";

                    int statusCode = (int)HttpStatusCode.InternalServerError;

                    context.Response.StatusCode = statusCode;

                    var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
                    {
                        Title = "Unexpected Error",
                        Status = statusCode,
                        Detail = errorDetails,
                        Instance = Guid.NewGuid().ToString()
                    };

                    var json = JsonConvert.SerializeObject(problemDetails);

                    logger.LogError(json);

                    //============================================================
                    //Email error to support. Added to this class
                    //============================================================

                    string fixedsendToList = "johnpetersen1959@gmail.com,support@nyxium.dk";
                    Dictionary<string, string> tokens = new Dictionary<string, string>();

                    tokens.Add("systemErrorSubject", problemDetails.Title);
                    tokens.Add("systemErrorDetails", problemDetails.Detail);
                    tokens.Add("systemErrorIdentifier", problemDetails.Instance);

                    EmailUtility emailUtility = new EmailUtility(env);                   
                    AlternateView htmlView = emailUtility.getFormattedBodyByMailtemplate(EmailUtility.MailTemplateType.SupportTicketSystemError, tokens);
                    emailUtility.send(fixedsendToList, "support@nyxium.dk", "System fejl i nyxium", htmlView, true);

                    //============================================================
                    //Return response
                    //============================================================
                    var matchText = "JSON";

                    bool requiresJsonResponse = context.Request
                                                        .GetTypedHeaders()
                                                        .Accept
                                                        .Any(t => t.Suffix.Value?.ToUpper() == matchText
                                                                  || t.SubTypeWithoutSuffix.Value?.ToUpper() == matchText);

                    if (requiresJsonResponse)
                    {
                        context.Response.ContentType = "application/json; charset=utf-8";

                        if (!respondWithJsonErrorDetails)
                            json = JsonConvert.SerializeObject(new
                            {
                                Title = "Unexpected Error"
                                                                   ,
                                Status = statusCode
                            });
                        await context.Response
                                        .WriteAsync(json, Encoding.UTF8);
                    }
                    else
                    {
                        context.Response.Redirect(errorPagePath);
                                             
                        await Task.CompletedTask;
                    }
                });
            });
        }
    }
}

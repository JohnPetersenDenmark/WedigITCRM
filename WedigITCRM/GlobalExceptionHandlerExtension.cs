using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
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
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app, IRelateCompanyAccountWithUserRepository relateCompanyAccountWithUserRepository, IWebHostEnvironment env,  ILogger logger, string errorPagePath, bool respondWithJsonErrorDetails = false)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(  async context =>
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

                    // var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails

                    ProblemDetailsExtended problemDetailsExtended = new ProblemDetailsExtended()
                    {
                        Title = "Unexpected Error",
                        Status = statusCode,
                        Detail = errorDetails,
                        Instance = Guid.NewGuid().ToString()
                    };


                    if (context.Request.HttpContext.User.Identity.IsAuthenticated)
                    {

                        var userName = context.User.FindFirst(ClaimTypes.Name);
                        problemDetailsExtended.UserName = userName.Value;

                        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                        problemDetailsExtended.UserId = userId;


                        IRelateCompanyAccountWithUserRepository relateCompanyAccountWithUserRepository = context.RequestServices.GetService<IRelateCompanyAccountWithUserRepository>();

                        List<RelateCompanyAccountWithUser> relationList =  relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(relation => relation.user.Equals(userId)).ToList();

                        if (relationList.Count == 1)
                        {
                            RelateCompanyAccountWithUser relation = relationList.First();
                            if ( relation != null)
                            {
                                int companyAccountId = relation.companyAccount;
                                ICompanyAccountRepository companyAccountRepository = context.RequestServices.GetService<ICompanyAccountRepository>();
                                CompanyAccount companyAccount = companyAccountRepository.GetCompanyAccount(companyAccountId);
                                if (companyAccount != null)
                                {
                                    problemDetailsExtended.CompanyId = companyAccountId.ToString();
                                    problemDetailsExtended.CompanyName = companyAccount.CompanyName;
                                }
                            }
                        }
                    }

                    var json = JsonConvert.SerializeObject(problemDetailsExtended);

                    logger.LogError(json);


                    //============================================================
                    //Email error to support. JLP Added this code
                    //============================================================

                    string fixedsendToList = "johnpetersen1959@gmail.com,support@nyxium.dk";
                    Dictionary<string, string> tokens = new Dictionary<string, string>();

                    tokens.Add("systemErrorSubject", problemDetailsExtended.Title);
                    tokens.Add("systemErrorDetails", problemDetailsExtended.Detail);
                    tokens.Add("systemErrorIdentifier", problemDetailsExtended.Instance);
                    tokens.Add("systemErrorUserId", problemDetailsExtended.UserId);
                    tokens.Add("systemErrorUserName", problemDetailsExtended.UserName);
                    tokens.Add("systemErrorCompanyId", problemDetailsExtended.CompanyId);
                    tokens.Add("systemErrorCompanyName", problemDetailsExtended.CompanyName);

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

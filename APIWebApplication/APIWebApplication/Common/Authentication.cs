using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace APIWebApplication.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Authentication : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            //WebApplicationLogBL webApplicationLogBL = null;
            //string validationMessage = Messages.TokenRequired;
            try
            {
                string apitoken = string.Empty;

                if (HttpContext.Current.Request.Headers["apitoken"] != null)
                {
                    apitoken = HttpContext.Current.Request.Headers["apitoken"];
                }
                if (actionContext != null)
                {
                    if (apitoken != null && apitoken.Length > 0)
                    {
                        //webApplicationLogBL = new WebApplicationLogBL();
                        ////Check if token is valid 
                        //WebApplicationLog obj = webApplicationLogBL.ValidateToken(apitoken);
                        //if (obj != null && obj.apitoken != null)
                        //{
                        //    IIdentity userIdentity = new ApiIdentity(true, obj.userid, obj.apitoken);
                            //IPrincipal principal = new ApiPrincipal(userIdentity);
                            //actionContext.ControllerContext.RequestContext.Principal = null;
                            //actionContext.Response = new HttpResponseMessage(HttpStatusCode.OK);

                        return base.IsAuthorized(actionContext);
                    }
                    else
                    {

                        //actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, validationMessage);
                        return false;
                    }
                }
                    else
                    {
                        //actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, validationMessage);
                        return false;
                    }
                
            }
            catch (Exception ex)
            {
                //actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, ex.Message);
            }
            return false;
        }
    }
}
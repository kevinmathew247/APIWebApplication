using APIWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace APIWebApplication.Common
{
    public class WrappingHandler: System.Net.Http.DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            return BuildApiResponse(request, response);
        }
        private static HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response)
        {


            object content;
            HttpResponseMessage httpResponseMessage;
            Response objResponse = new Response();
            int statusCode = (int)response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                if (response.ReasonPhrase != null)
                {
                    string errorMessage = response.ReasonPhrase;
                   


                    objResponse.status = statusCode;
                    objResponse.message = errorMessage;

                }

            }
            else
            {
                response.TryGetContentValue(out content);
                objResponse.data = (content == null ? new object() : content);
                objResponse.status = statusCode;

            }
            httpResponseMessage = request.CreateResponse<Response>(response.StatusCode, objResponse);
            return httpResponseMessage;
        }
    }
}
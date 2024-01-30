using HRLeaveManagement.MVC.Contracts;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace HRLeaveManagement.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly ILocalStorgeService _localStorage;

        protected IClient _client;

        public BaseHttpService(IClient client, ILocalStorgeService localStorgeService)
        {
            _client = client;
            _localStorage = localStorgeService;
        }

        protected Response<Guid> ConvertApiException<Guid>(ApiException ex)
        {
            if(ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation errors have occured.", ValidationErrors = ex.Response, Success = false };
            }
            else if(ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The requested item could not found.", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "something went wrong, please try again.", Success = false };
            }
        }   

        protected void AddBearerToken()
        {
            if (_localStorage.Exists("Token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("bearer", _localStorage.GetStorgeValue<string>("Token"));
            }   
            
        }
    }
}

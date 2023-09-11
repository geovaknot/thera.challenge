using Newtonsoft.Json;
using System.Threading.Tasks;
using Thera.Talent.Management.Web.ExternalService.AppApi.Common;
using Thera.Talent.Management.Web.ExternalService.AppApi.Interfaces;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Request;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Response;

namespace Thera.Talent.Management.Web.ExternalService.AppApi
{
    public class AppApiService : IAppApiService
    {
        private readonly IAppApiProxy _appApiProxy;

        public AppApiService(
            IAppApiProxy appApiProxy)
        {
            _appApiProxy = appApiProxy;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var response = await _appApiProxy.Login(request);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content);
            return JsonConvert.DeserializeObject<LoginResponse>(content);
        }

        public async Task<GetUsersResponse> GetUsers(HeaderRequest header)
        {
            var response = await _appApiProxy.GetUsers(header);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content);
            return JsonConvert.DeserializeObject<GetUsersResponse>(content);
        }

        public async Task<GetUserResponse> GetUser(HeaderRequest header, int request)
        {
            var response = await _appApiProxy.GetUser(header, request);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content);
            return JsonConvert.DeserializeObject<GetUserResponse>(content);
        }

        public async Task<bool> CreateUser(HeaderRequest header, CreateUserRequest request)
        {
            var response = await _appApiProxy.CreateUser(header, request);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content);
            return JsonConvert.DeserializeObject<bool>(content);
        }

        public async Task<bool> UpdateUser(HeaderRequest header, UpdateUserRequest request)
        {
            var response = await _appApiProxy.UpdateUser(header, request);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content);
            return JsonConvert.DeserializeObject<bool>(content);
        }

        public async Task<bool> DeleteUser(HeaderRequest header, int request)
        {
            var response = await _appApiProxy.DeleteUser(header, request);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content);
            return JsonConvert.DeserializeObject<bool>(content);
        }

        public async Task<GetTalentsResponse> GetTalents(HeaderRequest header)
        {
            var response = await _appApiProxy.GetTalents(header);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content);
            return JsonConvert.DeserializeObject<GetTalentsResponse>(content);
        }

        public async Task<GetTalentResponse> GetTalent(HeaderRequest header, int request)
        {
            var response = await _appApiProxy.GetTalent(header, request);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content);
            return JsonConvert.DeserializeObject<GetTalentResponse>(content);
        }

        public async Task<bool> CreateTalent(HeaderRequest header, CreateTalentRequest request)
        {
            var response = await _appApiProxy.CreateTalent(header, request);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content);
            return JsonConvert.DeserializeObject<bool>(content);
        }

        public async Task<bool> UpdateTalent(HeaderRequest header, UpdateTalentRequest request)
        {
            var response = await _appApiProxy.UpdateTalent(header, request);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content);
            return JsonConvert.DeserializeObject<bool>(content);
        }

        public async Task<bool> DeleteTalent(HeaderRequest header, int request)
        {
            var response = await _appApiProxy.DeleteTalent(header, request);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content);
            return JsonConvert.DeserializeObject<bool>(content);
        }
    }
}
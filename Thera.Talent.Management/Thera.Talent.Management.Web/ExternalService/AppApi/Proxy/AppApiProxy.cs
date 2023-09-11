using System.Net.Http;
using System.Threading.Tasks;
using Thera.Talent.Management.Web.ExternalService.AppApi.Common;
using Thera.Talent.Management.Web.ExternalService.AppApi.Interfaces;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Request;

namespace Thera.Talent.Management.Web.ExternalService.AppApi.Proxy
{
    public class AppApiProxy : IAppApiProxy
    {
        private readonly string _urlLogin;
        private readonly string _urlGetUsers;
        private readonly string _urlGetUser;
        private readonly string _urlCreateUser;
        private readonly string _urlUpdateUser;
        private readonly string _urlDeleteUser;
        private readonly string _urlGetTalents;
        private readonly string _urlGetTalent;
        private readonly string _urlCreateTalent;
        private readonly string _urlUpdateTalent;
        private readonly string _urlDeleteTalent;

        public AppApiProxy(
            AppApiSettings settings)
        {
            _urlLogin = settings.UrlLogin;
            _urlGetUsers = settings.UrlGetUsers;
            _urlGetUser = settings.UrlGetUser;
            _urlCreateUser = settings.UrlCreateUser;
            _urlUpdateUser = settings.UrlUpdateUser;
            _urlDeleteUser = settings.UrlDeleteUser;
            _urlGetTalents = settings.UrlGetTalents;
            _urlGetTalent = settings.UrlGetTalent;
            _urlCreateTalent = settings.UrlCreateTalent;
            _urlUpdateTalent = settings.UrlUpdateTalent;
            _urlDeleteTalent = settings.UrlDeleteTalent;
        }

        public async Task<HttpResponseMessage> Login(LoginRequest request)
        {
            return await AppApiMethods.Post(new HeaderRequest(""), request, _urlLogin);
        }

        public async Task<HttpResponseMessage> GetUsers(HeaderRequest header)
        {
            return await AppApiMethods.Get(header, _urlGetUsers);
        }

        public async Task<HttpResponseMessage> GetUser(HeaderRequest header, int request)
        {
            return await AppApiMethods.Get(header, string.Format(_urlGetUser, request));
        }

        public async Task<HttpResponseMessage> CreateUser(HeaderRequest header, CreateUserRequest request)
        {
            return await AppApiMethods.Post(header, request, _urlCreateUser);
        }

        public async Task<HttpResponseMessage> UpdateUser(HeaderRequest header, UpdateUserRequest request)
        {
            return await AppApiMethods.Put(header, request, string.Format(_urlUpdateUser, request.Id));
        }

        public async Task<HttpResponseMessage> DeleteUser(HeaderRequest header, int request)
        {
            return await AppApiMethods.Delete(header, string.Format(_urlDeleteUser, request));
        }

        public async Task<HttpResponseMessage> GetTalents(HeaderRequest header)
        {
            return await AppApiMethods.Get(header, _urlGetTalents);
        }

        public async Task<HttpResponseMessage> GetTalent(HeaderRequest header, int request)
        {
            return await AppApiMethods.Get(header, string.Format(_urlGetTalent, request));
        }

        public async Task<HttpResponseMessage> CreateTalent(HeaderRequest header, CreateTalentRequest request)
        {
            return await AppApiMethods.Post(header, request, _urlCreateTalent);
        }

        public async Task<HttpResponseMessage> UpdateTalent(HeaderRequest header, UpdateTalentRequest request)
        {
            return await AppApiMethods.Put(header, request, string.Format(_urlUpdateTalent, request.Id));
        }

        public async Task<HttpResponseMessage> DeleteTalent(HeaderRequest header, int request)
        {
            return await AppApiMethods.Delete(header, string.Format(_urlDeleteTalent, request));
        }
    }
}
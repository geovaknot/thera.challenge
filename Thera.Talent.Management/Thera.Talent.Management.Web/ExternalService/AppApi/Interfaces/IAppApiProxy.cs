using System.Net.Http;
using System.Threading.Tasks;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Request;

namespace Thera.Talent.Management.Web.ExternalService.AppApi.Interfaces
{
    public interface IAppApiProxy
    {
        Task<HttpResponseMessage> Login(LoginRequest request);
        Task<HttpResponseMessage> GetUsers(HeaderRequest header);
        Task<HttpResponseMessage> GetUser(HeaderRequest header, int request);
        Task<HttpResponseMessage> CreateUser(HeaderRequest header, CreateUserRequest request);
        Task<HttpResponseMessage> UpdateUser(HeaderRequest header, UpdateUserRequest request);
        Task<HttpResponseMessage> DeleteUser(HeaderRequest header, int request);
        Task<HttpResponseMessage> GetTalents(HeaderRequest header);
        Task<HttpResponseMessage> GetTalent(HeaderRequest header, int request);
        Task<HttpResponseMessage> CreateTalent(HeaderRequest header, CreateTalentRequest request);
        Task<HttpResponseMessage> UpdateTalent(HeaderRequest header, UpdateTalentRequest request);
        Task<HttpResponseMessage> DeleteTalent(HeaderRequest header, int request);
    }
}

using System.Threading.Tasks;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Request;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Response;

namespace Thera.Talent.Management.Web.ExternalService.AppApi.Interfaces
{
    public interface IAppApiService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<GetUsersResponse> GetUsers(HeaderRequest header);
        Task<GetUserResponse> GetUser(HeaderRequest header, int request);
        Task<bool> CreateUser(HeaderRequest header, CreateUserRequest request);
        Task<bool> UpdateUser(HeaderRequest header, UpdateUserRequest request);
        Task<bool> DeleteUser(HeaderRequest header, int request);
        Task<GetTalentsResponse> GetTalents(HeaderRequest header);
        Task<GetTalentResponse> GetTalent(HeaderRequest header, int request);
        Task<bool> CreateTalent(HeaderRequest header, CreateTalentRequest request);
        Task<bool> UpdateTalent(HeaderRequest header, UpdateTalentRequest request);
        Task<bool> DeleteTalent(HeaderRequest header, int request);
    }
}

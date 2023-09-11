using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Thera.Talent.Management.Web.Common.Exceptions;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Request;

namespace Thera.Talent.Management.Web.ExternalService.AppApi.Common
{
    public class AppApiMethods
    {
        public async static Task<HttpResponseMessage> Post<T>(HeaderRequest header, T request, string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                if (!string.IsNullOrEmpty(header.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header.AccessToken);
                }

                var data = JsonConvert.SerializeObject(request);
                var buffer = Encoding.UTF8.GetBytes(data);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                return await client.PostAsync(url, byteContent);
            }
        }

        public async static Task<HttpResponseMessage> Put<T>(HeaderRequest header, T request, string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                if (!string.IsNullOrEmpty(header.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header.AccessToken);
                }

                var data = JsonConvert.SerializeObject(request);
                var buffer = Encoding.UTF8.GetBytes(data);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                return await client.PutAsync(url, byteContent);
            }
        }

        public async static Task<HttpResponseMessage> Get(HeaderRequest header, string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                if (!string.IsNullOrEmpty(header.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header.AccessToken);
                }

                return await client.GetAsync(url);
            }
        }

        public async static Task<HttpResponseMessage> Delete(HeaderRequest header, string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                if (!string.IsNullOrEmpty(header.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header.AccessToken);
                }

                return await client.DeleteAsync(url);
            }
        }

        public static void ResponseService(HttpResponseMessage response, string content)
        {
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new DomainException("500", "Internal Server Error");
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new DomainException("401", "Você não tem permissão para essa ação!");
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                dynamic c = JsonConvert.DeserializeObject<dynamic>(content);
                throw new DomainException(response.StatusCode.GetHashCode().ToString(), c.Message.ToString());
            }
        }
    }
}
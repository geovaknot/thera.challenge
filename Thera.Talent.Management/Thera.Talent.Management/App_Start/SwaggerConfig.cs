using Swashbuckle.Application;
using System.Web.Http;

namespace Thera.Talent.Management
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            config
                  .EnableSwagger(c =>
                  {
                      c.SingleApiVersion("v1", "Thera.Talent.Management.Api");
                      c.ApiKey("token")
                          .Description("Token de autenticação JWT")
                          .Name("Authorization")
                          .In("header");
                      c.IncludeXmlComments(GetXmlCommentsPath());
                  })
                  .EnableSwaggerUi(c =>
                  {

                  })
                  ;
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\Thera.Talent.Management.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}

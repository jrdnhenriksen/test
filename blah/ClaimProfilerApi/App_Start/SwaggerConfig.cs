using WebActivatorEx;
using ClaimProfilerApi;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ClaimProfilerApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            //GlobalConfiguration.Configuration
            //    .EnableSwagger(c => c.SingleApiVersion("v1", "ClaimProfilerApi"))
            //    .EnableSwaggerUi();   
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using ResilientGraphSDKRequests.Configuration;
using ResilientGraphSDKRequests.Policies;
using ResilientGraphSDKRequests.ServiceClients;

namespace ResilientGraphSDKRequests
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var graphOptions = new MSGraphOptions();
            Configuration.Bind("MSGraph", graphOptions);

            services.AddSingleton(graphOptions);

            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create(graphOptions.GraphClientId)
                .WithTenantId(graphOptions.TenantID)
                .WithClientSecret(graphOptions.GraphClientSecret)
                .Build();

            var mSGraphauthProvider = new ClientCredentialProvider(confidentialClientApplication, "https://graph.microsoft.com/.default");

            services.AddSingleton(mSGraphauthProvider);

            services.AddHttpClient<IMSGraphServiceClientAdaptor, MSGraphServiceClientAdaptor>(PolicyNames.GraphHttpClient)
                .AddPolicyHandler(HttpPolicies.GetRetryPolicy());

            services.AddSingleton<IMSGraphServiceClientAdaptor, MSGraphServiceClientAdaptor>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

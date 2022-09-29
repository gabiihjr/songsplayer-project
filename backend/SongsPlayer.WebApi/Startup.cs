using Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using Utility.Middleware;
using WebApi.Configurations;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Console.WriteLine($"Starting Startup");
            Console.WriteLine($"Env: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
        }

        public IConfiguration Configuration { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute($"{Configuration["Api:BaseRoute"]}/api/{Configuration["Api:Version"]}"));
            });
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddJwtAsymmetricAuthentication(Configuration);
            services.AddSignalR();
            services.AddCors();

            /*REMOVE BEFORE FLIGHT*/
            services.AddAntiforgery(x => x.SuppressXFrameOptionsHeader = true);

            RegisterServices(services);
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            /*REMOVE BEFORE FLIGHT*/
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Remove("X-Frame-Options");
                context.Response.Headers.Remove("x-frame-options");
                await next();
            });


            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Viewer}/{action=Index}/{id?}");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            DependencyContainer.RegisterServices(services);
        }
    }
}

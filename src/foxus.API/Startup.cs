using Foxus.Infrastructure.Data.DataRegistration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Foxus.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddDataRegistration(_configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "foXus API",
                    Version = "v1",
                    Description = "API da aplica��o foXus, desenvolvida durante o 8 semestre do curso de Engenharia da Computa��o pela Faculdade Engenheiro Salvador Arena" +
                    "<br><br><b>Integrantes do grupo:</b> " +
                    "<br><br>Carlos Alexandre - RA 081190017" +
                    "<br>Danillo Alves Rodrigues - RA 081190036" +
                    "<br>Giovanni Medici - RA 081190005" +
                    "<br>Guilherme Brito - RA 0811900",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foxus.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
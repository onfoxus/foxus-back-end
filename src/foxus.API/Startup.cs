using Foxus.API.Helper;
using Foxus.Infrastructure.Data.DataRegistration;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.Text;

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
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDataRegistration(_configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "foXus API",
                    Version = "v2",
                    Description = "API of the foXus application, developed during the 8th semester of the Computer Engineering course at Faculdade Engenheiro Salvador Arena" +
                    "<br><br><b>Integrantes do grupo:</b> " +
                    "<br><br>Carlos Alexandre - RA 081190017" +
                    "<br>Danillo Alves Rodrigues - RA 081190036" +
                    "<br>Giovanni Medici - RA 081190005" +
                    "<br>Guilherme Brito - RA 0811900",
                });
            });
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "Foxus.API v2"));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
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
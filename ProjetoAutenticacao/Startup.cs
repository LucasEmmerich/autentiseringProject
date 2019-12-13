using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjetoAutenticacao.DatabaseContext;
using ProjetoAutenticacao.Security;
using ProjetoAutenticacao.Security.Authorization;
using ProjetoAutenticacao.Services;

namespace ProjetoAutenticacao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<Context>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<AuthService>();
            services.AddMvc(o =>
            {
                o.Filters.Add(typeof(AuthorizationFilter));
                o.EnableEndpointRouting = false;
            });
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(j =>
            {
                j.RequireHttpsMetadata = false;
                j.SaveToken = true;
                j.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Qualquer coisa")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Contact = new OpenApiContact
                    {
                        Email = "laemmerich@gmail.com / lucas.emmerich@cefet-rj.br",
                        Name = "Lucas",
                        Url = new System.Uri("https://github.com/LucasEmmerich")
                    },
                    Description = "Serviço de Autenticação",
                    Title = "Autentisering Project",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Authorization",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "O token de autenticação deve ser mandado no cabeçalho da requisição!",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                //c.AddSecurityDefinition("AppId",
                //    new OpenApiSecurityScheme
                //    {
                //        In = ParameterLocation.Header,
                //        Description = "A identificação do aplicativo deve ser mandada no cabeçalho da requisição apenas !",
                //        Name = "AppId",
                //        Type = SecuritySchemeType.Http
                //    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement());
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Autentisering Project");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}

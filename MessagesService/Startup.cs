using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


namespace MessagesService
{
    public class Startup(IConfiguration config)
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMemoryCache();

            services.AddCors();
            services.AddMvc();

            services.AddControllers();
            services.AddHttpClient();
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Scheme = "bearer",
                    BearerFormat = "jwt-bearer",
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            services.AddRouting(urls => urls.LowercaseUrls = true);
            // services.Configure<CleanupOptions>(config.GetSection("CleanupOptions"));
            // services.AddHostedService<OldTransitionsRemover>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseSwagger();
            app.UseSwaggerUI();




            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
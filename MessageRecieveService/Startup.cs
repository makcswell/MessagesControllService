using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace MessageRecieveService
{
    public class Startup(IConfiguration config)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMemoryCache();

            services.AddCors();
            services.AddMvc();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                
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
            //services.AddHostedService<MessageRecieveService>();
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
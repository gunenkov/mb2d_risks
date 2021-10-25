using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using WebApplication1.BackgroundService;
using WebApplication1.Models;

namespace WebApplication1
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
            services.AddCors(options => options.AddDefaultPolicy(builder => builder
                 .SetIsOriginAllowedToAllowWildcardSubdomains()
                 .WithOrigins(Configuration.GetSection("Cors:Origins").Get<string[]>())
                 .AllowAnyMethod()
                 .AllowCredentials()
                 .AllowAnyHeader()
             ));

            services.AddControllers().AddNewtonsoftJson(options =>
   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
            //services.AddEntityFrameworkSqlite().AddDbContext<DataBaseContext>();

            /* services.AddDbContext<DataBaseContext>(db =>
             {
                 var contentRoot = Configuration[HostDefaults.ContentRootKey];
                 var path = Path.Combine(Path.GetDirectoryName(contentRoot), "DB.db");
                 db.UseSqlite($"Data Source={path}");
             });*/
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataBaseContext>(options =>
                 options.UseSqlServer(connection));

            /* var connection = Configuration.GetConnectionString("DefaultConnection");
             services.AddDbContext<DataBaseContext>(options =>
                 options.UseSqlServer(connection));*/
            services.AddHostedService<CheckStatusEventLog>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

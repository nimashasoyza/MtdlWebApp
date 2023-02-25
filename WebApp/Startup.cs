using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Authorization;
using WebApp.DataAcces;
using WebApp.Helpers;
using WebApp.Services;

namespace WebApp
{
    public class Startup
    {
        public string DbConnectionString { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DbConnectionString = configuration.GetConnectionString("DbConnectionString");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Configure DBContext with SQL
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(DbConnectionString));

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<IVideoService, VideoService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
        }
    }
}

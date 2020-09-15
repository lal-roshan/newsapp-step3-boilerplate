using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service;

namespace NewsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NewsDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("NewsReminderDbCon"))
                );
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IReminderRepository, ReminderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IReminderService, ReminderService>();
            services.AddScoped<IUserService, UserService>();

            services.AddControllers();
            //provide options for DbContext 
            //Note:Add ConnectionStrings key in appsettings.json and use Connectionstring name here

            //Register all dependencies required for this Project
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

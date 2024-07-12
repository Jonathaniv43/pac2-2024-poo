using BlogUNAH.Api.Services;
using BlogUNAH.API.Database;
using BlogUNAH.API.Helpers;
using BlogUNAH.API.Services;
using BlogUNAH.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogUNAH.API
{
    public class Startup
    {
        private  IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
           Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            var name = Configuration.GetConnectionString("DefaultConnection");
            //Add DbContext
            services.AddDbContext<BlogUNAHContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // Add Custom Services
            //services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<ICategoriesService, CategoriesSQLService>();
            services.AddTransient<IAuthService, AuthService>();

            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}

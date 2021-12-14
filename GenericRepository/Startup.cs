using GenericRepository.GenericRepository.Context;
using GenericRepository.GenericRepository.UserRepository;
using GenericRepository.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace GenericRepository
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>(); // 1 client 1 , (Singleton) butun client lar için 1 tane , (Transient)

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                ));

            services.AddControllersWithViews();

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
                endpoints.MapDefaultControllerRoute();
            });
            using (var provider = app.ApplicationServices.CreateScope())
            {
                using var context = provider.ServiceProvider.GetRequiredService<ApplicationDbContext>();


                context.Database.Migrate();
                context.Database.EnsureCreated();
                if (!context.Users.Any())
                {
                    context.Users.Add(new User
                    {
                        FirstName = "Huseyin",
                        LastName = "Cumalı",
                        UserName = "hcumalı"
                    });

                    context.SaveChanges();
                }
            }


        }
    }
}

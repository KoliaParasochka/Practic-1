using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectDb.EF;
using ProjectDb.Initial;
using ProjectDb.Storage;
using Microsoft.Extensions.Hosting;

namespace Users
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            if(configuration != null)
            {
                Configuration = configuration;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationContext>(option
                => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IUnitOfWork, EFUnitOfWork>(); // Uses for constructor injection
            services.AddMvc();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                ApplicationContext db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                InitDb.Initial(db);
            }
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            else
            {
                app.UseExceptionHandler("Home/Error");
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();

           
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            
            
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}

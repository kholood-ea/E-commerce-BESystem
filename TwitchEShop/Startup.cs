using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchEShop.Interfaces;
using TwitchEShop.Services;
using Microsoft.EntityFrameworkCore;
using TwitchEShop.Dal;
using TwitchEShop.Domain.Interfaces;
using TwitchEShop.Dal.Repositories;

namespace TwitchEShop
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
            services.AddControllers();
            var cs = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<EShopDBContext>(options => options.UseSqlServer(cs));
            services.AddScoped<IProductRepository, ProductRepositoy>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            //doesnt add product when post
            //services.AddScoped<ISeeder, Seeder>();
            services.AddSingleton<ISeeder, Seeder>();

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
        }
    }
}

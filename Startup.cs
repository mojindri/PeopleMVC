using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assessment_server_side.CSVDataSource;
using assessment_server_side.Repository;
using assessment_server_side.Models;
using assessment_server_side.Models.Factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Update.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using assessment_server_side.EntityDataSource;
using AutoMapper;

namespace assessment_server_side
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
            services.AddDbContext<PersonsContext>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddLogging(opt => { opt.AddConsole(); opt.AddDebug();});
            services.AddSingleton<IFavouriteColorRepository, FavouriteColorCSVFileRepository>();
            //services.AddSingleton<IFavouriteColorRepository, EntityFrameworkServiceCollectionExtensions>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory logger)
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

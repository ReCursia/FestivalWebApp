using AutoMapper;
using FestivalWebApp.API.Mappings;
using FestivalWebApp.BLL;
using FestivalWebApp.Core.Repositories;
using FestivalWebApp.Core.Services;
using FestivalWebApp.DAL;
using FestivalWebApp.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FestivalWebApp.API
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

            services.AddScoped<IFestivalService, FestivalService>();
            services.AddScoped<IParticipantService, ParticipantService>();

            services.AddTransient<IFestivalRepository, FestivalRepository>();
            services.AddTransient<IParticipantRepository, ParticipantRepository>();

            services.AddDbContext<FestivalDatabaseContext>(options =>
                options.UseInMemoryDatabase("FestivalWebApp"));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo {Title = "Festival Application", Version = "v.1.0"});
            });

            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();

            app.UseSwaggerUI(o =>
            {
                o.RoutePrefix = "";
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "Festival Application v.1.0");
            });
        }
    }
}
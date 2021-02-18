using Bowling.Score.Calculator.Infrastructure.Filters;
using Bowling.Score.Calculator.Services;
using Bowling.Score.Calculator.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bowling.Score.Calculator
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
            services.AddControllers(options =>
           {
               options.Filters.Add(typeof(HttpGlobalExceptionFilter));
           });
            services.AddSwaggerDocument( config =>
            {
                config.PostProcess = doc => {
                    doc.Info.Title = "Bowling Score Calculator API";
                };
            });

            services.AddScoped<IGameValidator, GameValidator>();
            services.AddScoped<IScoreCalculator, ScoreCalculator>();
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
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

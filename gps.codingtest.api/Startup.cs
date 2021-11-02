using gps.codingtest.core.ServiceInterfaces;
using gps.codingtest.core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace gps.codingtest.api
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GPS.CodingTest.Api", Version = "v1" });
            });

            services.AddSingleton(typeof(IStatusService), typeof(StatusService));
            services.AddTransient(typeof(IEmailService), typeof(EmailService));
            services.AddTransient(typeof(ISmsService), typeof(SmsService));
            services.AddTransient(typeof(IEmailNotificationService), typeof(EmailNotificationService));
            services.AddTransient(typeof(ISmsNotificationService), typeof(SmsNotificationService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GPS.CodingTest.Api v1"));
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

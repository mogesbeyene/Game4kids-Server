using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games4Kids
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
            services.AddCors(setup => setup.AddPolicy("Application", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


            services.Configure<ApiBehaviorOptions>(o => o.SuppressModelStateInvalidFilter = true);
            services.AddDbContext<Games4KidsContext>(o => o.UseSqlServer(Configuration.GetConnectionString("localDB")));
            services.AddTransient<AuthLogic>();
            services.AddTransient<GameSettingLogic>();
            services.AddTransient<MatchRecordLogic>();
            services.AddTransient<PlayerRecordLogic>();
            services.AddControllers();


            JwtHelper jwtHelper = new JwtHelper(Configuration.GetValue<string>("JWT:Key"));
            services.AddSingleton(jwtHelper);
            services.AddAuthentication(o => jwtHelper.SetAuthenticationOptions(o)).AddJwtBearer(o => jwtHelper.SetBearerOptions(o));
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

            app.UseCors("Application");

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

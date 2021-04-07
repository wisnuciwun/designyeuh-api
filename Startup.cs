using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using designyeuh_api.Models;
using Microsoft.Extensions.Hosting;
using MySqlConnector;

namespace designyeuh_api
{
    public class Startup
    {
        // private string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();                
            Configuration = builder.Build();
        }
        
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            // string connectionString = Configuration.GetConnectionString("DefaultConnection");
            // services.AddDbContext<MasterContext>(opt => opt.UseSqlServer(connectionString));
            // services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["ConnectionStrings:DefaultConnection"]));
  
            services.AddDbContext<MasterContext>(opt => opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();  

            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

                services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                .WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseHsts();
            }

            app.UseAuthentication();

            app.UseCors("CorsPolicy");

            app.UseMvc();
            
        }
    }
}

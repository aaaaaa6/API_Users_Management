using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cliente.Model;
using Cliente.UseCase;
using Cliente.MSSql;
using Cliente.UseCase.Interfaces;
using Cliente.MSSql.IRNegocio;
using Cliente.MSSql.Repository;
using Cliente.MSSql.Adapter;
using Microsoft.EntityFrameworkCore;

namespace Cliente.AppServices
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "AllowOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            var origins = Configuration.GetSection("AllowedOrigins").Get<string[]>();



            services.AddDbContext<ConnectionDataMsSql>(options => options
                                               .UseSqlServer(Configuration.GetConnectionString("PruebaSD"))
                                               );


            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cliente.AppServices", Version = "v1" });
            });


            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionString"));
            


            //Business Class
            services.AddScoped<IUsuario, UsuarioBusiness>();



            //Repository Class
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cliente.AppServices v1"));
            }

            app.UseCors(MyAllowSpecificOrigins);

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

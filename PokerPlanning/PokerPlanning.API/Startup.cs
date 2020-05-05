using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PokerPlanning.API.Hubs;
using PokerPlanning.Core.Interfaces;
using PokerPlanning.Core.Services;
using PokerPlanning.Infrastructure.Context;
using PokerPlanning.Infrastructure.Interfaces;
using PokerPlanning.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace PokerPlanning.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //CORS
            services.AddCors(opt =>
            {
                opt.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
            //Db Context
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("PokerPlanning"));

            //Repositories
            services.AddScoped<IRoomRepository, RoomRepository>();

            //Services
            services.AddScoped<IRoomService, RoomService>();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kroton Poker Planning",
                    Version = "1.0.0",
                    Description = "Kroton Poker Planning API",
                    Contact = new OpenApiContact
                    {
                        Name = "Pierre Tinchant Pinto",
                        Email = "ptinchant@360rh.com.br"
                    }
                });
                //// Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSignalR();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Poker Planning API");
            });

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

#pragma warning disable CS0618 // Type or member is obsolete
            app.UseSignalR(builder =>
            {
                builder.MapHub<RoomHub>("/roomhub");
            });
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}

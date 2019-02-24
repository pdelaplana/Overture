using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using NSwag.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Overture.Core.Application.AutoMapper.Profiles;
using Overture.Core.Application.AutoMapper.Resolvers;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;
using Overture.Core.Services;
using Overture.Infrastructure.Persistance.MongoDB;
using Overture.Infrastructure.Services.Auth0;

namespace Overture.Web.API
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
			services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.Configure<RepositorySettings>(Configuration.GetSection("MongoDb"));
			services.Configure<Auth0Settings>(Configuration.GetSection("Auth0ManagementApi"));


			services.AddOpenApiDocument(document => 
			{
				document.Title = "Overture API";
				document.DocumentName = "v1";
			});
			//services.AddSwaggerDocument();

			services.AddMediatR();
			services.AddScoped<MongoDBContext>();
			services.AddScoped<IBusinessServiceRepository, BusinessServiceRepository>();
			services.AddScoped<IBusinessServiceCategoryRepository, BusinessServiceCategoryRepository>();
			services.AddScoped<IBusinessRepository, BusinessRepository>();

			services.AddScoped<IUserService, Auth0UserService>();

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});


			services.AddAutoMapper();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseSwagger(settings => { });
			app.UseSwaggerUi3(settings => { });

			app.UseCors(builder =>
				builder
					//.AllowAnyOrigin()
					.WithOrigins("http://localhost:4200")
					.AllowAnyHeader()
					.AllowAnyMethod()

				);

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501

				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
				}
			});

			
		}	


		
	}

}

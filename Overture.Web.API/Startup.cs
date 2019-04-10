using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
using Overture.Core.Repositories;
using Overture.Core.Services;
using Overture.Infrastructure.Persistance.MongoDB;
using Overture.Infrastructure.Services.Auth0;
using Overture.Web.API.Authentication;
using NSwag.SwaggerGeneration.Processors.Security;
using NSwag;

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

			//
			// Global Settings 
			//
			services.Configure<RepositorySettings>(Configuration.GetSection("MongoDb"));
			services.Configure<Auth0Settings>(Configuration.GetSection("Auth0"));
			services.Configure<Auth0ManagementSettings>(Configuration.GetSection("Auth0ManagementApi"));
			
			services.AddOpenApiDocument(document => 
			{
				document.Title = "Overture API";
				document.DocumentName = "v1";
				
				document.DocumentProcessors.Add(
					new SecurityDefinitionAppender("oauth2", new SwaggerSecurityScheme
					{
						Type = SwaggerSecuritySchemeType.OAuth2,
						Description = "Foo",
						Flow = SwaggerOAuth2Flow.Implicit,
						//AuthorizationUrl = "https://localhost:44333/core/connect/authorize",
						AuthorizationUrl = $"https://snapquotes.auth0.com/authorize?audience={Configuration["Auth0:Audience"]}",
						TokenUrl = "https://localhost:44333/core/connect/token",
						Scopes = new Dictionary<string, string>
						{
							{ "read", "Read access to protected resources" },
							{ "write", "Write access to protected resources" }
						}
					})
				);

				document.OperationProcessors.Add(
					new OperationSecurityScopeProcessor("oauth2"));
				

			});

			/*
			services.AddSwaggerDocument(document => {
				// Add an authenticate button to Swagger for JWT tokens
				document.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
				document.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT", new SwaggerSecurityScheme
				{
					Type = SwaggerSecuritySchemeType.ApiKey,
					Name = "Authorization",
					In = SwaggerSecurityApiKeyLocation.Header,
					Description = "Type into the textbox: Bearer {your JWT token}."
				}));
			});
			*/
			services.AddMediatR();
			services.AddScoped<MongoDBContext>();
			services.AddScoped<IBusinessServiceRepository, BusinessServiceRepository>();
			services.AddScoped<IBusinessServiceCategoryRepository, BusinessServiceCategoryRepository>();
			services.AddScoped<IBusinessRepository, BusinessRepository>();
			services.AddScoped<IReviewRepository, ReviewRepository>();

			services.AddScoped<IFileStoreService, FileStoreService>();
			services.AddScoped<IUserService, Auth0UserService>();
			services.AddScoped<IAuthenticationService, Auth0AuthenticationService>();
			services.AddScoped<IMetaInformationService, MetaInformationService>();


			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});

			//
			// Automapper
			//
			services.AddAutoMapper();

			//
			// Auth0 Authentication
			//
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

			}).AddJwtBearer(options =>
			{
				options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
				options.Audience = Configuration["Auth0:Audience"];
			});

			services.AddAuthorization(options =>
			{
				options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", $"https://{Configuration["Auth0:Domain"]}/")));
			});

			// register the scope authorization handler
			services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

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

			app.UseSwagger(settings => {

			});
			app.UseSwaggerUi3(settings => {
				
				settings.OAuth2Client = new OAuth2ClientSettings
				{
					ClientId = Configuration["Auth0:ClientId"],
					ClientSecret = Configuration["Auth0:ClientSecret"],
					AppName = "SnapQuotes",
					Realm = "Username-Password-Authentication",
					
					AdditionalQueryStringParameters =
					{
						{ "foo", "bar" }
					}
				};
				
			});

			app.UseCors(builder =>
				builder
					//.AllowAnyOrigin()
					.WithOrigins("http://localhost:4200")
					.AllowAnyHeader()
					.AllowAnyMethod()

				);

			app.UseAuthentication();

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

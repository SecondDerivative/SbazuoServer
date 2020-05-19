using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sbazuo.Server.Backend;
using Sbazuo.Server.Backend.Accounts.PasswordComparers;
using Sbazuo.Server.Models.Converters.Contracts;

namespace SbazuoServer {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services
				.AddSingleton<IAccountService, DefaultAccountService>()
				.AddSingleton<IPasswordComparer, EqualPasswordComparer>()
				.AddSingleton<IConverterContractResolver, DefaultConverterContractResolver>()
				.AddSingleton<ISessionService, DefaultSessionService>()
				.AddSingleton<ILobbyService, DefaultLobbyService>()
				.AddControllers()
				.AddNewtonsoftJson();
			//services.AddSingleton<HelloWorldController>();
			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection()
			.UseRouting()
			.UseAuthorization()
			.UseEndpoints(endpoints => {
				//endpoints.MapControllers();
				endpoints.MapControllerRoute(
						name: "default",
						pattern: "{controller=HelloWorld}/{action=Index}"
					);
			});
		}
	}
}

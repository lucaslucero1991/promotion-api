using CalendarWebApi.Services;
using CalendarWebApi.Controllers.Validators;
using CalendarWebApi.Controllers;
using CalendarWebApi.Gateway;

namespace CalendarWebApi
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
            // Registrar servicios y dependencias
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<ISubscriptionGateway, SubscriptionGateway>();
            services.AddScoped<IValidatorFactory, ValidatorFactory>();
            services.AddScoped<ProviderFactory>();

            services.AddHttpClient("LaNacionClient", client =>
            {
                client.BaseAddress = new Uri("https://qa-clnvalidaciones.lanacion.com.ar");
                client.DefaultRequestHeaders.Add("x-api-key", "6ygbD92yNj6caRkL2zqiZ5gWpNizswTR7soRxe61");
            });

            services.AddScoped<ValidatorFactory>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

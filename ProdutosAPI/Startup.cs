using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProdutosApi.Models;
using ProdutosApi.Services;
using ProdutosAPI.Services;

namespace ProdutosAPI
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
            services.Configure<ProdutosDatabaseSettings>(
                Configuration.GetSection(nameof(ProdutosDatabaseSettings)));

            services.AddSingleton<IProdutosDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ProdutosDatabaseSettings>>().Value);

            services.AddSingleton<ProdutoService>();

            services.AddScoped<IProdutoService, ProdutoService>();


            services.AddMvc();
            services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "ProdutosAPI", Version = "v1" });
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
             {
                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProdutosAPI v1");
             });
        }
    }
}

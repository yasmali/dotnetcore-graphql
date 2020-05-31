using GraphQL;
using GraphQL.Types;
using GraphQlMaster.Core;
using GraphQlMaster.ServiceFoundation.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphQlMaster.Api.Graphql;
using GraphQlMaster.Api.Graphql.Types;
using GraphQlMaster.Api.Helpers;
using GraphQlMaster.Business.Repositories;
using GraphiQl;

namespace GraphQlMaster.Api
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
            services.AddHttpContextAccessor();
            services.AddSingleton<ServiceLocator>();
            services.AddDbContext<MarketingContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:GraphQlMasterDb"]));

            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IMaterialRepository, MaterialRepository>();
            services.AddTransient<IPurchaseHistoryRepository, PurchaseHistoryRepository>();

            services.AddSingleton<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<MaterialType>();
            services.AddSingleton<BrandType>();
            services.AddSingleton<PurchaseHistoryType>();
            services.AddSingleton<MarketingQuery>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new MarketingSchema(new FuncDependencyResolver(type => sp.GetService(type))));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MarketingContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            db.EnsureSeedData();
            app.UseGraphiQl("/graphql");
        }
    }
}

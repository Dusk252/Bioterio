using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bioterio.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Bioterio.Validation;

namespace Bioterio
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
            services.AddDbContext<bd_lesContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc(o =>
            {
                /*o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor (
                    value =>
                    SiteResources.CustomImplicitRequired);*/
                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor (
                    (value, fieldName) =>
                    string.Format(SiteResources.PropertyValueInvalid, fieldName));
                /*o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor (
                    fieldName =>
                        string.Format(SiteResources.CustomNumeric, fieldName));*/
                o.ModelMetadataDetailsProviders.Add(
                    new CustomValidationMetadataProvider(
                        "Bioterio.SiteResources",
                        typeof(SiteResources)));

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Mvc.Authorization;
using Zellis.HRSauce.Filters;

namespace Zellis.HRSauce
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            if (this.Environment.IsDevelopment())
            {
                // This blocks aggressive caching.
                services.AddMemoryCache();
            }

            services.AddRazorPages();
            var mvcBuilder = services.AddControllersWithViews();

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Timing filter for page footer
            services.AddMvc(options =>
            {
                options.Filters.Add(new GlobalTimingFilter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
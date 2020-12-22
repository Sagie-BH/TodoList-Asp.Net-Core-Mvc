using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using TodoList.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL.DataContext;
using DAL.Repositories;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace TodoList
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
            services.AddMemoryCache();

            services.AddControllersWithViews();

            services.AddControllers();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Changing default password settings.

                //options.Password.RequireDigit = false;
                //options.Password.RequireNonAlphanumeric = false;
                //options.Password.RequireUppercase = false;
                //options.Password.RequiredLength = 5;
                //options.Password.RequiredUniqueChars = 2;

            }).AddEntityFrameworkStores<DatabaseContext>();

            services.AddDbContextPool<DatabaseContext>(ops => ops.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc(opt => 
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();   // Use Authentication for the all website
                opt.Filters.Add(new AuthorizeFilter(policy));   // Adding new policy rule
            }
            ).AddXmlSerializerFormatters();

            services.AddAuthorization(options => { 
                options.AddPolicy("DeleteRolePolicy",
                policy => policy.RequireClaim("Delete Role"));

                options.AddPolicy("EditRolePolicy",
                policy => policy.RequireClaim("Edit Role", "true"));

                options.AddPolicy("CreateRolePolicy",
                policy => policy.RequireClaim("Create Role"));
            });

            services.AddScoped(typeof(IRepository<TodoObjectModel>), typeof(TodoRepository));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddControllers().AddNewtonsoftJson();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Todo}/{action=Todo}/{id?}");
            });
        }
    }
}

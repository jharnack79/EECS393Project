﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GetThiqqq.Services;
using GetThiqqq.Repository;

namespace GetThiqqqBase
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
            services.AddMvc();
            services.AddScoped<IUserAccount, UserAccount>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped(typeof(UserAccountRepository));
            services.AddScoped(typeof(ForumPostRepository));
            services.AddScoped(typeof(RoutineRepository));
            services.AddScoped(typeof(ExerciseRepository));
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IForumPostRepository, ForumPostRepository>();
            services.AddScoped<IForumTopicRepository, ForumTopicRepository>();
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IRoutineRepository, RoutineRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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

using Account.Application.Business;
using Account.Infrastructure.MySql;
using Account.Infrastructure.MySql.Repositories;
using Account.Interface.Business;
using Account.Interface.Infra;
using Accounts.WebApi.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Accounts.WebApi
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
            services.AddValidations();

            var connection = Configuration["ConexaoMySql:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>(options =>
                options.UseMySql(connection)
            );

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAccountServiceRepository, AccountService>();
            services.AddScoped<ITransferRepository, TransferRepository>();
            services.AddScoped<ITransferServiceRepository, TransferService>();

            //services.AddScoped<IAccount, AccountService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation()
                .AddJsonOptions(o => o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore); ;

            // 
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Account API", Version = "V1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);



                var app = PlatformServices.Default.Application;
                var path = app.ApplicationBasePath;

                var files = Directory.GetFiles(path, "*.xml");
                foreach (var item in files)
                    c.IncludeXmlComments(item);
                
            });


            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            // 
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });

            app.UseMvc();
        }
    }
}

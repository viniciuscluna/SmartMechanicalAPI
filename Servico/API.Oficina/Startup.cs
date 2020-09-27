using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Oficina.Hubs;
using API.Oficina.Model;
using API.Oficina.Profile;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Infra.Comum.Email.ValueObjects;
using Infra.Data.Contexto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace API.Oficina
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(o => o.AddPolicy("DefaultPolicy", builder =>
            {
                builder
                //.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowCredentials()
                       .AllowAnyHeader()
                       .SetIsOriginAllowed((host) => true) ;
            }));


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CarroProfile());
                cfg.AddProfile(new ClienteProfile());
                cfg.AddProfile(new EntidadeBaseProfile());
                cfg.AddProfile(new MecanicoProfile());
                cfg.AddProfile(new OficinaProfile());
                cfg.AddProfile(new OrdemServicoProfile());
                cfg.AddProfile(new ServicoOrdemServicoProfile());
                cfg.AddProfile(new ServicoProfile());
                cfg.AddProfile(new EntidadeAutenticarProfile());
                cfg.AddProfile(new BasicOrdemServicoProfile());
                cfg.AddProfile(new PreAberturaOSProfile());
                cfg.AddProfile(new PerguntaOSAlternativaProfile());
                cfg.AddProfile(new PerguntaOSProfile());
                cfg.AddProfile(new PreOrdemServicoProfile());
            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDbContext<OficinaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbAzure")));

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            // Deixar response de forma Maiuscula      .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //JWT


            var token = Configuration.GetSection("tokenManagement").Get<Token>();
            services.AddSingleton(token);
            services.AddSignalR();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = token.Issuer,
                        ValidAudience = token.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(token.Secret)
                            )

                    };
                    options.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = context =>
                        {
                            //System.Diagnostics.Debug.WriteLine("Não autenticado "+context.Exception.Message );
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            //System.Diagnostics.Debug.WriteLine("Autenticado " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };



                });

            services
                .AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            services.AddOptions();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac, like:
            builder.RegisterModule(new AutoFacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("DefaultPolicy");
            app.UseAuthentication();
           
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapDefaultControllerRoute();
                endpoint.MapHub<OSHub>("/hub");
            });

            app.UseHttpsRedirection();

        }
    }
}

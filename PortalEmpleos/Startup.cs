using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using System.IO;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Db.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Bussines.Auth;
using Bussines.Administracion;
using Bussines.Shared;

namespace PortalEmpleos
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
            services.AddCors();
            services.AddSingleton(Configuration);
            //services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            services.AddDbContext<PortalEmpleoDbContext>(opt =>
                opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"), serverVersion)
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors()
            );

            services.AddIdentity<Usuario, Rol>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Lockout.MaxFailedAccessAttempts = 6;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            })
             .AddEntityFrameworkStores<PortalEmpleoDbContext>()
             .AddDefaultTokenProviders();

            services.AddHealthChecks();
            services.AddMvc();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddTransient<IMailService, MailService>();
            /*Repositorios*/
            services.AddScoped<AuthRepository>();
            services.AddScoped<ProfileRepository>();
            services.AddScoped<ChatRepository>();
            services.AddScoped<BuzonRepository>();
            services.AddScoped<ExperienciaLaboralRepository>();
            services.AddScoped<OfertasLaboralesRepository>();
            services.AddScoped<DetailReository>();
            services.AddScoped<EmpleadosRepository>();
            services.AddScoped<SuscripcionesRepository>();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                //options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
                //options.OutputFormatters.Add(new HtmlOutputFormatter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);



            /*JWT*/
            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:Issuer"],
                    ValidIssuer = Configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                };
            });


            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            /*SWAGGER*/
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api Portal Empleos REST",
                    Version = "v1",
                    Description = "Prospectiva API",
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Email = string.Empty,
                        Url = new Uri("https://prospectiva.com"),
                    }

                });
                //Obtenemos el directorio actual
                var basePath = AppContext.BaseDirectory;
                //Obtenemos el nombre de la dll por medio de reflexión
                var assemblyName = System.Reflection.Assembly
                              .GetEntryAssembly().GetName().Name;
                //Al nombre del assembly le agregamos la extensión xml
                var fileName = System.IO.Path
                              .GetFileName(assemblyName + ".xml");
                //Agregamos el Path, es importante utilizar el comando
                // Path.Combine ya que entre windows y linux 
                // rutas de los archivos
                // En windows es por ejemplo c:/Uusuarios con / 
                // y en linux es \usr con \
                var xmlPath = Path.Combine(basePath, fileName);
                c.IncludeXmlComments(xmlPath);
                // To Enable authorization using Swagger (JWT)
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "En el campo de 'value' hay que agregar 'Bearer', espacio y el token. Ej Bearer xksd2k3jjs8sd8h23jn2m"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            });
            //this.AdddSawager(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            /*Habilitar swagger*/
            app.UseSwagger(c=>
            {
                c.RouteTemplate = "swagger/{documentname}/swagger.json";
            });
            /*Indica la rta para generar la configuración de swagger*/
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Api Portal Empleos REST");
                c.RoutePrefix = "swagger";
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                //if (env.IsDevelopment())
                //{
                //    spa.UseAngularCliServer(npmScript: "start");
                //    spa.Options.StartupTimeout = TimeSpan.FromSeconds(200);
                //}
            });

        }
    }
}

using AutoMapper;
using BuildingManagementSystem.Base;
using BuildingManagementSystem.Business;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BuildingManagementSystem.Service;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public static JwtConfig JwtConfig { get; private set;}
    public void ConfigureServices(IServiceCollection services)
    {
        //services.AddHangfire(x => x.UseSqlServerStorage("Server=DESKTOP-2PUAJM9;Database=ManagementDb;User Id=selin;Password=selin123456;Encrypt=False;Pooling=true"));
        //services.AddHangfireServer();
        services.AddControllers();

            JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
            services.AddDbContext<ManagementDbContext>(options => options.UseSqlServer(dbConfig));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperConfig());
            });
            services.AddSingleton(config.CreateMapper());

            services.AddScoped<IResidentService, ResidentService>();
            services.AddScoped<IFlatService, FlatService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<ICardInformationService, CardInformationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserLogService, UserLogService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddAuthentication(s =>
            {
                s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(s =>
            {
                s.RequireHttpsMetadata = true;
                s.SaveToken = true;
                s.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Startup.JwtConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Startup.JwtConfig.Secret)),
                    ValidAudience = Startup.JwtConfig.Audience,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(2)
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ManagementDbContext", Version = "v1" });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Building Management System",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {securityScheme, new string[] {}}
                });
            });
        }
 

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", " Building-Management-System v1"));
        }

        app.UseAuthentication();
       // app.UseHangfireDashboard();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}


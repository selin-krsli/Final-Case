using AutoMapper;
using BuildingManagementSystem.Business;
using BuildingManagementSystem.Data;
using BuildingManagementSystem.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BuildingManagementSystem;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ManagementDbContext", Version = "v1" });
        });
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

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", " Building-Management-System v1"));
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}


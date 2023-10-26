using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRJRepository.Interface;
using PRJRepository.Models;
using PRJRepository.Repo;
using TCManagementSystem.AutoMapper;

internal class Program
{
    private static void Main(string[] args)
    {
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<TcdatabaseContext>
             (options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

        builder.Services.AddDbContext<TcdatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

        builder.Services.AddTransient<IClientRepo, ClientRepo>();
        builder.Services.AddTransient<IOrganizationRepo, OrganizationRepo>();
        builder.Services.AddTransient<IClinicRepo, ClinicRepo>();
        builder.Services.AddTransient<IAppointmentRepo, AppointmentRepo>();
        builder.Services.AddTransient<IAvailableSlotRepo, AvailableSlotRepo>();
        builder.Services.AddTransient<IInvoiceRepo, InvoiceRepo>();
        builder.Services.AddTransient<IClinicLocationRepo, ClinicLocationRepo>();
        builder.Services.AddTransient<IBillingSettingRepo, BillingSettingRepo>();
        builder.Services.AddTransient<IServiceSettingRepo, ServiceSettingRepo>();
        builder.Services.AddTransient<IInsurranceSettingRepo, InsurranceSettingRepo>();
        builder.Services.AddTransient<ICalenderSettingRepo, CalenderSettingRepo>();
        builder.Services.AddTransient<IClientFormRepo, ClientFormRepo>();
        builder.Services.AddTransient<IUserRepo, UserRepo>();
        builder.Services.AddTransient<ILicenseRepo, LicenseRepo>();
        builder.Services.AddTransient<ICheckAvailabilityRepo, CheckAvailabilityRepo>();
        builder.Services.AddTransient<IAppointmentPaymentRepo, AppointmentPaymentRepo>();


        var mapperConfiguration = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapperProfiles());
        });
        IMapper mapper = mapperConfiguration.CreateMapper();
        builder.Services.AddSingleton(mapper);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              policy =>
                              {
                                  policy.WithOrigins("http://localhost:4200",
                                                      "https://localhost:4200")
                                                        .AllowAnyHeader()
                                                          .AllowAnyMethod();
                              });
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors(MyAllowSpecificOrigins);
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
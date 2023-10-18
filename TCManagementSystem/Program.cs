using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        builder.Services.AddTransient<IUserRepo, UserRepo>();
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
        builder.Services.AddTransient<IForm1Repo, Form1Repo>();
        builder.Services.AddTransient<IForm2Repo, Form2Repo>();
        builder.Services.AddTransient<IForm3Repo, Form3Repo>();
        builder.Services.AddTransient<IForm4Repo, Form4Repo>();
        builder.Services.AddTransient<IForm5Repo, Form5Repo>();
        builder.Services.AddTransient<IForm6Repo, Form6Repo>();
        builder.Services.AddTransient<IForm7Repo, Form7Repo>();
        builder.Services.AddTransient<IForm8Repo, Form8Repo>();
        builder.Services.AddTransient<IForm9Repo, Form9Repo>();
        builder.Services.AddTransient<IForm10Repo, Form10Repo>();
        builder.Services.AddTransient<IForm11Repo, Form11Repo>();
        builder.Services.AddTransient<IForm12Repo, Form12Repo>();
        builder.Services.AddTransient<IForm13Repo, Form13Repo>();
        builder.Services.AddTransient<IForm14Repo, Form14Repo>();
        builder.Services.AddTransient<IForm15Repo, Form15Repo>();
        builder.Services.AddTransient<IForm16Repo, Form16Repo>();
        builder.Services.AddTransient<IForm17Repo, Form17Repo>();
        builder.Services.AddTransient<IForm18Repo, Form18Repo>();
        builder.Services.AddTransient<IForm19Repo, Form19Repo>();
        builder.Services.AddTransient<IForm20Repo, Form20Repo>();

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
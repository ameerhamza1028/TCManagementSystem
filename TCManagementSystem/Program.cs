using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRJRepository.EntityModel;
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
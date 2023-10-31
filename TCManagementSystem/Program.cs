using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PRJRepository.Interface;
using PRJRepository.Models;
using PRJRepository.Repo;
using System.Text;
using TCManagementSystem.AutoMapper;

internal class Program
{
    private static void Main(string[] args)
    {
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        var builder = WebApplication.CreateBuilder(args);

        //Add Services
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true
            };
        });

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TCQuantumz.APIs", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
        });

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
        builder.Services.AddTransient<ILoginRepo, LoginRepo>();
        builder.Services.AddTransient<IMessageRepo, MessageRepo>();
        builder.Services.AddTransient<IEditClientRepo, EditClientRepo>();
        builder.Services.AddTransient<IPhoneRepo, PhoneRepo>();
        builder.Services.AddTransient<IClientAddressRepo, ClientAddressRepo>();
        builder.Services.AddTransient<ICardRepo, CardRepo>();
        builder.Services.AddTransient<IInsuranceRepo, InsuranceRepo>();
        builder.Services.AddTransient<IServiceRepo, ServiceRepo>();
        builder.Services.AddTransient<IEmailRepo, EmailRepo>();



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
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TC.API V1");
        });

        // Configure the HTTP request pipeline.
       /* if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }*/
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors(MyAllowSpecificOrigins);
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
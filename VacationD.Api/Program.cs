using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using VacationD.Api.Middleware;
using VacationD.Core;
using VacationD.Core.Repositories;
using VacationD.Core.Services;
using VacationD.Data.Repositories;
using DataContext = VacationD.Data.DataContext;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Console.WriteLine(builder.Configuration["USERNAME"]);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddDbContext<DataContext>();
        //builder.Services.AddDbContext<DataContext>(
        //    options => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_db"));
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IUserService, UserService>();
        //builder.Services.AddSingleton<Mapping>();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddScoped<IWorkHoursCalculator, WorkHoursCalculator>();
        builder.Services.AddScoped<IWorkingHoursRepository, WorkingHoursRepository>();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseMiddleware<ShabatMiddleware>();

        app.MapControllers();

        app.Run();
        WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);

        app.UseAuthentication();

        app.UseAuthorization();
        
        

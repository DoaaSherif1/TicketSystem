
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using TicketSystem.BL.Managers.Departments;
using TicketSystem.BL.Managers.Tickets;
using TicketSystem.DAL.Data.Context;
using TicketSystem.DAL.Data.Models;
using TicketSystem.DAL.Repos.Departments;
using TicketSystem.DAL.Repos.Tickets;

namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Context

            //Don't store connection string in appsettings.json, use UserSecrets instead.
            var connectionString = builder.Configuration.GetConnectionString("tickets_ConString");
            builder.Services.AddDbContext<TicketContext>(options =>
                options.UseSqlServer(connectionString)); //registered as scoped

            #endregion

            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
            builder.Services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();

            builder.Services.AddScoped<ITicketsManager, TicketsManager>();
            builder.Services.AddScoped<IDepartmentsManager, DepartmentsManager>();

            builder.Services.AddIdentity<Developer, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<TicketContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Cool";
                options.DefaultChallengeScheme = "Cool";
            })
                .AddJwtBearer("Cool", options =>
                {
                    string keyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
                    var keyInBytes = Encoding.ASCII.GetBytes(keyString);
                    var key = new SymmetricSecurityKey(keyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            builder.Services.AddAuthorization(options =>
            {

                options.AddPolicy("Admins", policy => policy
                    .RequireClaim(ClaimTypes.Role, "admin")
                    .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy("Users", policy => policy
                    .RequireClaim(ClaimTypes.Role, "user", "admin")
                    .RequireClaim("Nationality", "Egyptian")
                    .RequireClaim(ClaimTypes.NameIdentifier));
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


            app.MapControllers();

            app.Run();
        }
    }
}
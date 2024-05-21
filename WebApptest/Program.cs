
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApptest.Context;
using WebApptest.Context.UnitOfWork;
using WebApptest.Extensions;
using WebApptest.Repository;
using WebApptest.Service;

namespace WebApptest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WebApptestContext>(option =>
            {
                string connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
                var serverVersion = ServerVersion.AutoDetect(connectionString);
                option.UseMySql(connectionString, serverVersion);
            }).AddUnitOfWork<WebApptestContext>()
           .AddCustomRepository<User, UserRepository>();

            builder.Services.AddTransient<ILoginService, LoginService>();
            
            var automapperConfog = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProFile());
            });

            builder.Services.AddSingleton(automapperConfog.CreateMapper());
            // Add services to the container.

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

            app.UseHttpsRedirection();
            
            app.UseAuthorization();
            app.MapControllers();
            //这是一个测试代码
            app.Run();
        }
    }
}

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using UserDB_API_NET.Models;

namespace UserDB_API_NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddDbContext<TestUserDataContext>(options =>
            //    options.UseSqlite("Data Source=D:\\Coding Projects\\_Python\\DataToCSVFile\\TestUserData.db"));


            //Used that construction to have possibility to redefine the timeout
            builder.Services.AddDbContext<TestUserDataContext>(options =>
            {
                var connection = new SqliteConnection("Data Source=D:\\Coding Projects\\_Python\\DataToCSVFile\\TestUserData.db")
                {
                    DefaultTimeout = 60
                };

                options.UseSqlite(connection);
            });

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

            app.Run();
        }
    }
}

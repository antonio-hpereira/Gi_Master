
using API_Loan_Simulator.Common;
using API_Loan_Simulator.Context;
using API_Loan_Simulator.Core_Simulator;
using API_Loan_Simulator.Core_Simulator.ISimulator;
using API_Loan_Simulator.Repository.Concrete;
using API_Loan_Simulator.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_Loan_Simulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura o DbContext com SQL Server
            builder.Services.AddDbContext<DBHack_Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConectionString")));

            builder.Services.AddDbContext<MemoryContext>(options =>
             options.UseInMemoryDatabase("BancoMemoria"));


            builder.Services.AddScoped<ISimuladorFinanciamento, SimuladorFinanciamento>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();



            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

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

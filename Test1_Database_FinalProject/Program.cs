using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Test1_Database_FinalProject.Context;

namespace Test1_Database_FinalProject
{
    internal class Program
    {
        private static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Nackademin\Databasteknik\Projekt\Test1_Database_FinalProject\Context\Db_Examination.mdf;Integrated Security=True;Connect Timeout=30";
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));
            }).Build();

            await host.RunAsync();  
        }
    }
}
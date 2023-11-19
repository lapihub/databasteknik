using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Test2_Database_Library.Context;

namespace Test2_Database_Library
{
    internal class Program
    {
        private static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Nackademin\Databasteknik\Projekt\Test2_Database_Library\Test2_Database_Library\Context\db_Examination2.mdf;Integrated Security=True;Connect Timeout=30";
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
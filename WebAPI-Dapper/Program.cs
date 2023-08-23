using DbUp;
using FluentMigrator.Runner;
using WebApi_Domain.IRepository;
using WebApi_Infrastructure.ApplicationDbContext;
using WebApi_Infrastructure.Migrations;
using WebApi_Infrastructure.Repository;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<DapperContext>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

        var serviceProvider = CreateServices();
        using (var scope = serviceProvider.CreateScope())
        {
            UpdateDatabase(scope.ServiceProvider);
        }

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.MapControllers(); 

        app.Run();
    }

    private static IServiceProvider CreateServices()
    {
        string connectionstring = "";
        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer2016()
                .WithGlobalConnectionString(connectionstring)
               .ScanIn(typeof(Initial_202125100001).Assembly, typeof(Seed_202125100002).Assembly).For.Migrations())
                .BuildServiceProvider(false); 
    }

    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>(); 
        runner.MigrateUp();  // Command to Run regular migrations

        // Run paticular seeding migration manually
        //var seedingMigration = new Seed_202125100002(); // Create an instance of your seeding migration class
        //seedingMigration.Up(); 
    }
}

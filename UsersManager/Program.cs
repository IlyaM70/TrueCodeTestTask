using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UsersManager.Data;
using UsersManager.Services;
using UsersManager.Services.Interfaces;


var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context,services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(context.Configuration.GetConnectionString("MsSqlServer"));
                });
        services.AddTransient<IApp,App>();
        services.AddTransient<IUserService,UserService>();
    })
    .ConfigureLogging(logging => {
        logging.ClearProviders();
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    //run migration
    dbContext.Database.Migrate();

    var app = scope.ServiceProvider
        .GetRequiredService<IApp>();
    app.Run();

}





using BlogUNAH.API;
using BlogUNAH.API.Database;

var builder = WebApplication.CreateBuilder(args);


var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);

// en este punto la aplicaion ya esta cargada y puede usar todo los servicios
using (var scope = app.Services.CreateScope()) // en memoria hasta que termine el codigo dentro de el 
{
    // nos deja utilizar todos los servicios dentro del sistema
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
   
    try
    {
        // me da una instancia del contexto
        var context = services.GetRequiredService<BlogUNAHContext>();
        await BlogUNAHSeeder.LoadDataAsync(context, loggerFactory);
    }
    catch (Exception e)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(e, "Error al ejecutar el seed de Datos");
        
    }
}


app.Run();

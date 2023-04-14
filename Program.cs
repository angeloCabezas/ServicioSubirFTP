using ServicioSubirFTP;
using ServicioSubirFTP.Configuraciones;
using ServicioSubirFTP.Gestores;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        var appSettings = new AppSettings();
        hostContext.Configuration.Bind(appSettings);

        services.AddSingleton<AppSettings>(appSettings);
        // Para configuraciones de rutas
        services.AddSingleton<IConfiguraciones, ConfiguracionJson>();

        // Gestores de Proceso
        services.AddSingleton<IGestor, GestorSubidaFTP>();

        // Mediadores
        services.AddSingleton<IMediatorGestores, MediatorGestores>();

        // Servicio en si
        services.AddHostedService<Worker>();

    })
    .ConfigureLogging((hostContext,loggingBuilder) => {
        var path = "logs/app.log";
        Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .MinimumLevel.Debug()
                        .WriteTo.File(path, rollingInterval: RollingInterval.Day)
                        //outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] ({SourceContext}.{Method}) {Message}{NewLine}{Exception}") //Permite ingreso de templates
                        .CreateLogger();
        loggingBuilder.ClearProviders();
        loggingBuilder.AddSerilog();
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();

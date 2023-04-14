using ServicioSubirFTP;
using ServicioSubirFTP.Configuraciones;
using ServicioSubirFTP.Logger;
using ServicioSubirFTP.Gestores;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Para configuraciones de rutas
        services.AddSingleton<IConfiguraciones, ConfiguracionJson>();

        // Gestores de Proceso
        services.AddSingleton<IGestor, GestorSubidaFTP>();

        // Formas de auditoria
        services.AddSingleton<IASLogger, FileLogger>();
        services.AddSingleton<IASLogger, ConsoleLogger>();

        // Mediadores
        services.AddSingleton<IMediatorLogger, MediatorLogger>();
        services.AddSingleton<IMediatorGestores, MediatorGestores>();

        // Servicio en si
        services.AddHostedService<Worker>();

    })
    .UseWindowsService()
    .Build();

await host.RunAsync();

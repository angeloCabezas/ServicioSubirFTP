using ServicioSubirFTP.Configuraciones;
using ServicioSubirFTP.Gestores;

namespace ServicioSubirFTP
{
    public class Worker : BackgroundService
    {
        private readonly IMediatorGestores _gestores;//Por convencio todos los metodos que son private de la clase inician con _"minuscula"
        private readonly ILogger<Worker> _logger;
        private readonly AppSettings _appSettings;
        public Worker(ILogger<Worker> logger, IMediatorGestores gestores, AppSettings appSettings)
        {
            _logger = logger;
            _gestores = gestores;
            _appSettings = appSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Servicio SubirFTP Iniciando");
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _gestores.Publish();
                    await Task.Delay(_appSettings.TimeOutWorker, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Servicio SubirFTP Error {ex.Message}");
            }
            _logger.LogInformation("Servicio SubirFTP Finalizado");
        }
    }
}
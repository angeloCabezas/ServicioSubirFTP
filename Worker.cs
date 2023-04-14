using ServicioSubirFTP.Gestores;

namespace ServicioSubirFTP
{
    public class Worker : BackgroundService
    {
        private readonly IMediatorGestores Gestores;

        public Worker(IMediatorGestores gestores)
        {
            Gestores = gestores;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                Gestores.Publish();

                await Task.Delay(1000000, stoppingToken); 
            }
        }
    }
}
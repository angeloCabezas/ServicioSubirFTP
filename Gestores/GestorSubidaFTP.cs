using ServicioSubirFTP.Configuraciones; //Retirar directivas innecesarias para que el codigo este más limpio
using ServicioSubirFTP.Helper;

namespace ServicioSubirFTP.Gestores
{
    public class GestorSubidaFTP : IGestor
    {
        private readonly IConfiguraciones _configuraciones;//Si solo se usa para la clase poner la propiedad en privado
        private readonly ILogger<GestorSubidaFTP> _logger;
        //Considerarmos que el proposito de la clase es gestionar la subida, por lo que el methodo de subida de informacion FTP deberia estar en otra clase
        //podria ser en una clase injectada o en una clase statica
        public GestorSubidaFTP(ILogger<GestorSubidaFTP> logger,IConfiguraciones configuraciones)
        {
            _configuraciones = configuraciones;
            _logger = logger;
        }

        public void Handler()
        {

            DirectoryInfo di = new DirectoryInfo(_configuraciones.GetrutaFicheros);
            _logger.LogInformation($"Número de fiches a procesar {di.GetFiles().Count()}");

            foreach (var fi in di.GetFiles())
            {
                SubirFicherosAlFTP(fi.Name); //En order tu evitar comentarios, una buena practica es poner un nombre que describa el methodo 
                MueveFicherosAProcesados(fi.Name);
            }

        }

        public void SubirFicherosAlFTP(string fichero)
        {
            _logger.LogInformation($"Procesamos el fichero {fichero}");

            string ftpRemoteFilePath = _configuraciones.GetrutaFTP + fichero;
            string localFilePath = _configuraciones.GetrutaFicheros + fichero;

            HelperTrasnferencias.UploadFileToFtp(ftpRemoteFilePath,_configuraciones.GetusuarioFTP,_configuraciones.GetpasswordFTP,
                                                  localFilePath, _logger);
        }

        public void MueveFicherosAProcesados(string fichero)
        {
            string origen = _configuraciones.GetrutaFicheros + fichero;
            string destino = _configuraciones.GetrutaProcesados + fichero;

            _logger.LogInformation($"Movemos el fichero de {origen} a {destino}");

            if (File.Exists(destino))
            {
                _logger.LogInformation($"Ya existía el fichero en destino de procesados {destino}. Lo borramos");
                File.Delete(destino);
            }

            File.Move(origen, destino);

            if (File.Exists(origen))
            {
                _logger.LogWarning($"No se ha borrado el fichero original de {origen} !!!"); 
                //Añadimos esto como un warning porque no deberia generar un trycatch en el proceso
            }
        }
    }
}

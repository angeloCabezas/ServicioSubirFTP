using ServicioSubirFTP.Configuraciones; //Retirar directivas innecesarias para que el codigo este más limpio
using ServicioSubirFTP.Helper;

namespace ServicioSubirFTP.Gestores
{
    public class GestorSubidaFTP : IGestor
    {
        private readonly IConfiguracionFTP _configuraciones;//Si solo se usa para la clase poner la propiedad en privado
        private readonly ILogger<GestorSubidaFTP> _logger;
        //Considerarmos que el proposito de la clase es gestionar la subida, por lo que el methodo de subida de informacion FTP deberia estar en otra clase
        //podria ser en una clase injectada o en una clase statica
        public GestorSubidaFTP(ILogger<GestorSubidaFTP> logger,IConfiguracionFTP configuraciones)
        {
            _configuraciones = configuraciones;
            _logger = logger;
        }

        public void Handler()
        {

            DirectoryInfo di = new DirectoryInfo(_configuraciones.RutaFicherosAEnviar);
            _logger.LogInformation($"Número de fiches a procesar {di.GetFiles().Count()}");

            foreach (var fi in di.GetFiles())
            {
                SubirFicheroAFTP(fi.Name); //En order tu evitar comentarios, una buena practica es poner un nombre que describa el methodo 
                MueveFicheroAProcesados(fi.Name); //Auto recomendacion primero estaba con SubirFicherosAFTP => Pero solo sube archivo por archivo asi que es SubirFicheroAFTP
            }

        }

        public void SubirFicheroAFTP(string fichero)
        {
            _logger.LogInformation($"Procesamos el fichero {fichero}");

            //Create las variables necesarias antes de enviarlas
            string ftpRemoteFilePath = _configuraciones.RutaFicherosFTP + fichero;
            string localFilePath = _configuraciones.RutaFicherosAEnviar + fichero;

            HelperTrasnferencias.UploadFileToFtp(ftpRemoteFilePath,_configuraciones.UsuarioFTP,_configuraciones.PasswordFTP,
                                                  localFilePath, _logger);
        }

        public void MueveFicheroAProcesados(string fichero)
        {
            string origen = _configuraciones.RutaFicherosAEnviar + fichero;
            string destino = _configuraciones.RutaFicherosProcesados + fichero;

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

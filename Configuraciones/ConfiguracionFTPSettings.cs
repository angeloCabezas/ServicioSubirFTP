namespace ServicioSubirFTP.Configuraciones
{
    internal class ConfiguracionFTPSettings : IConfiguracionFTP
    {
        public FTPSettings settings;

        //Revisar que los nombres de las clases para el mismo tipo tengan la primera misma structura
        //Se cambia porque el nombre del archivo config.json esta en duro dentro de la clase y se deberia definir
        //La dependencia dentro del StartUp
        public ConfiguracionFTPSettings(FTPSettings ftpSettings) 
        {
            settings = ftpSettings;
        }
        public string PasswordFTP => settings.passwordFTP;

        public string RutaFicherosAEnviar => settings.rutaFicheros;

        public string RutaFicherosProcesados => settings.rutaProcesados;

        public string RutaFicherosFTP => settings.rutaFTP;

        public string UsuarioFTP => settings.usuarioFTP;

        public string FicheroLog => settings.ficheroLog;
    }
}

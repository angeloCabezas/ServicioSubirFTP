namespace ServicioSubirFTP.Configuraciones
{
    public class ConfiguracionFTPHardCode : IConfiguracionFTP
    {
        public FTPSettings settings = new FTPSettings();

        //public const string rutaFTP = @"ftp://ftp1.es.rhenus.com/TO_RFL/"; 
        //public const string usuarioFTP = "maquiten";
        //public const string passwordFTP = "VgX3811MSc";

        public ConfiguracionFTPHardCode()
        {
            settings.rutaFicheros = @"c:\actualiza\maquiten\ficheros\";
            settings.rutaProcesados = @"c:\actualiza\maquiten\ficheros\procesados\";
            settings.rutaFTP = @"ftp://192.168.30.28/Instalador/Raiz/Buzon/";
            settings.usuarioFTP = "sgamaquiten";
            settings.passwordFTP = "maquiten";
        }

        public string PasswordFTP => settings.passwordFTP;

        public string RutaFicherosAEnviar => settings.rutaFicheros;

        public string RutaFicherosProcesados => settings.rutaProcesados;

        public string RutaFicherosFTP => settings.rutaFTP;

        public string UsuarioFTP => settings.usuarioFTP;
        public string FicheroLog => settings.ficheroLog;

    }
}

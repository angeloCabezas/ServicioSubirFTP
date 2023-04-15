namespace ServicioSubirFTP.Configuraciones
{
    public class ConfiguracionFTPFactory
    {
        public IConfiguracionFTP CrearConfiguracionDesdeJson(FTPSettings ftpSettings)
        {
            return new ConfiguracionFTPSettings(ftpSettings);
        }
        public IConfiguracionFTP CrearConfiguracionDesdeHardCode()
        {
            return new ConfiguracionFTPHardCode();
        }
    }
}

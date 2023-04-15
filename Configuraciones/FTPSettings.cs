namespace ServicioSubirFTP.Configuraciones
{
    public sealed class FTPSettings
    {
        public string rutaFicheros { get; set; }
        public string rutaProcesados { get; set; }
        public string rutaFTP { get; set; }
        public string usuarioFTP { get; set; }
        public string passwordFTP { get; set; }
        public string ficheroLog { get; set; }
    }
}

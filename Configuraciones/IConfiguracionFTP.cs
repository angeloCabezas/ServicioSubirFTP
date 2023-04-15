namespace ServicioSubirFTP.Configuraciones
{
    public interface IConfiguracionFTP
    {
        public string RutaFicherosAEnviar { get; }
        public string RutaFicherosProcesados { get; }
        public string RutaFicherosFTP { get; }
        public string UsuarioFTP { get; }
        public string PasswordFTP { get; }
        public string FicheroLog { get; }

    }
}

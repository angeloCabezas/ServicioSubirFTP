using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSubirFTP.Configuraciones
{
    public class ConfiguracionesHardCode : IConfiguraciones
    {
        public Settings settings = new Settings();

        //public const string rutaFTP = @"ftp://ftp1.es.rhenus.com/TO_RFL/"; 
        //public const string usuarioFTP = "maquiten";
        //public const string passwordFTP = "VgX3811MSc";

        public ConfiguracionesHardCode()
        {
            settings.rutaFicheros = @"c:\actualiza\maquiten\ficheros\";
            settings.rutaProcesados = @"c:\actualiza\maquiten\ficheros\procesados\";
            settings.rutaFTP = @"ftp://192.168.30.28/Instalador/Raiz/Buzon/";
            settings.usuarioFTP = "sgamaquiten";
            settings.passwordFTP = "maquiten";
        }

        public string GetpasswordFTP => settings.passwordFTP;

        public string GetrutaFicheros => settings.rutaFicheros;

        public string GetrutaProcesados => settings.rutaProcesados;

        public string GetrutaFTP => settings.rutaFTP;

        public string GetusuarioFTP => settings.usuarioFTP;
        public string GetficheroLog => settings.ficheroLog;

    }
}

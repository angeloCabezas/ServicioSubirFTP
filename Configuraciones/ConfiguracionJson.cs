using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSubirFTP.Configuraciones
{
    internal class ConfiguracionJson : IConfiguraciones
    {
        public Settings settings;

        public ConfiguracionJson(/*string ficheroConfiguracion*/)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("config.json"/*ficheroConfiguracion*/) //"config.json"
                .AddEnvironmentVariables()
                .Build();

            // Get values from the config given their key and their target type.
            settings = config.GetRequiredSection("Settings").Get<Settings>();
        }
        public string GetpasswordFTP => settings.passwordFTP;

        public string GetrutaFicheros => settings.rutaFicheros;

        public string GetrutaProcesados => settings.rutaProcesados;

        public string GetrutaFTP => settings.rutaFTP;

        public string GetusuarioFTP => settings.usuarioFTP;

        public string GetficheroLog => settings.ficheroLog;
    }
}

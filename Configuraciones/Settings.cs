using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSubirFTP.Configuraciones
{
    public sealed class Settings
    {
        public string rutaFicheros { get; set; }
        public string rutaProcesados { get; set; }
        public string rutaFTP { get; set; }
        public string usuarioFTP { get; set; }
        public string passwordFTP { get; set; }
        public string ficheroLog { get; set; }
    }
}

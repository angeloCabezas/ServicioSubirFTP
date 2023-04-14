using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSubirFTP.Configuraciones
{
    public interface IConfiguraciones
    {
        public string GetrutaFicheros { get; }
        public string GetrutaProcesados { get; }
        public string GetrutaFTP { get; }
        public string GetusuarioFTP { get; }
        public string GetpasswordFTP { get; }
        public string GetficheroLog { get; }

    }
}

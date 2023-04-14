using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSubirFTP.Logger
{
    public enum ASLogLevel
    {
        Success,
        Warning,
        Information,
        Error
    };

    public class Activity
    {

        public string Message { get; set; }
        public string Module { get; set; }
        public DateTime CreatedDate { get; set; }
        public ASLogLevel Level { get; set; }

    }
}

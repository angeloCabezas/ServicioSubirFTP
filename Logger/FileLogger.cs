using ServicioSubirFTP.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSubirFTP.Logger
{
    public class FileLogger : IASLogger
    {

        readonly IConfiguraciones Configuraciones;

        public FileLogger(IConfiguraciones configuraciones)
        {
            Configuraciones = configuraciones;
        }

        public void Write(Activity activity)
        {
            string ficherolog = Configuraciones.GetrutaProcesados + Configuraciones.GetficheroLog;

            if (!File.Exists(ficherolog))
            {
                using (StreamWriter sw = File.CreateText(ficherolog))
                {
                    sw.WriteLine("{0}: {1}, {2}, {3}", nameof(activity.Level), activity.CreatedDate, activity.Module, activity.Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(ficherolog))
                {
                    sw.WriteLine("{0}: {1}, {2}, {3}", nameof(activity.Level), activity.CreatedDate, activity.Module, activity.Message);
                }
            }

        }

    }
}

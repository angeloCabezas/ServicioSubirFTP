using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSubirFTP.Logger
{
    public class ConsoleLogger : IASLogger
    {
        ~ConsoleLogger() => Console.ForegroundColor = ConsoleColor.White;

        public void Write(Activity activity)
        {
            switch (activity.Level)
            {
                case ASLogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case ASLogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case ASLogLevel.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ASLogLevel.Information:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            // Código para registrar la actividad
            Console.WriteLine("{0}, {1}, {2}", activity.CreatedDate, activity.Module, activity.Message);
        }

    }
}

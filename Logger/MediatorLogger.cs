using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSubirFTP.Logger
{
    public class MediatorLogger : IMediatorLogger
    {
        readonly IEnumerable<IASLogger> Loggers;

        public MediatorLogger(IEnumerable<IASLogger> loggers)
        {
            Loggers = loggers;
        }

        public void Publish(Activity activity)
        {
            Loggers.ToList().ForEach(l => l.Write(activity));
        }
    }
}

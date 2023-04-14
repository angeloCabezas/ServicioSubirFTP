using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSubirFTP.Logger
{
    public interface IMediatorLogger
    {
        void Publish(Activity activity);
    }
}

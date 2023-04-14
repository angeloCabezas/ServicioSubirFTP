using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSubirFTP.Gestores
{
    public class MediatorGestores : IMediatorGestores
    {
        readonly IEnumerable<IGestor> Gestores;
        public MediatorGestores(IEnumerable<IGestor> gestores)
        {
            Gestores = gestores;
        }

        public void Publish()
        {
            Gestores.ToList().ForEach(l => l.Handler());
        }
    }
}

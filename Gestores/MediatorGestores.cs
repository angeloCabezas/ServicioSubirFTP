//Retiramos metodos que no se usan para estar más limpios

namespace ServicioSubirFTP.Gestores
{
    public class MediatorGestores : IMediatorGestores
    {
        private readonly IEnumerable<IGestor> _gestores; //Agregamos private
        private readonly ILogger<MediatorGestores> _logger; 
        public MediatorGestores(ILogger<MediatorGestores> logger, IEnumerable<IGestor> gestores)
        {
            _logger = logger;
            _gestores = gestores;
        }

        public void Publish()
        {
            _logger.LogInformation("MediatorGestores - Inicio Proceso");

            if (_gestores.ToList().Count() == 0)
                throw new Exception("MediatorGestores - No hay gestores configurados"); //agregar exceptiones como validaciones de logica para que la capa externa los maneje

            _gestores.ToList().ForEach(l => l.Handler());
        }
    }
}

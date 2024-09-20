namespace FabricaObjetosRepository
{
    public class EstudianteRepositoryFactory : IFabricaRepository<EstudianteRepository>
    {
        public EstudianteRepository CrearRepository()
        {
            return new EstudianteRepository();
        }
    }
}

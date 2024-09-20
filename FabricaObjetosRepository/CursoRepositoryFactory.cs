namespace FabricaObjetosRepository
{
    public class CursoRepositoryFactory : IFabricaRepository<CursoRepository>
    {
        public CursoRepository CrearRepository()
        {
            return new CursoRepository();
        }
    }
}

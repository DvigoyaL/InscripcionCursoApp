namespace FabricaObjetosRepository
{
    public class ProgramaRepositoryFactory : IFabricaRepository<ProgramaRepository>
    {
        public ProgramaRepository CrearRepository()
        {
            return new ProgramaRepository();
        }
    }
}

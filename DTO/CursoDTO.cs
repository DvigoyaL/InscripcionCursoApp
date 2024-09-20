namespace DTO
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int ProgramaId { get; set; }
        public string NombrePrograma { get; set; }  // Nombre del programa al que pertenece el curso
    }

}

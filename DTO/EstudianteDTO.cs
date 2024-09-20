namespace DTO
{
    public class EstudianteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public int ProgramaId { get; set; }
        public string NombrePrograma { get; set; }  // Nombre del programa en el que está inscrito el estudiante
    }
}

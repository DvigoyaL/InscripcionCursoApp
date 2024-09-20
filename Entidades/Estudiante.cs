namespace Entidades
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public int ProgramaId { get; set; } // Relación con el programa
    }


}

namespace Entidades
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int ProgramaId { get; set; } // Relación con el programa
    }


}

namespace GestorDocumentos
{
    public class ServiciosDocumentos
    {
        public void ConvertirADocumentoWord(string nombreDocumento)
        {
            Console.WriteLine($"Convirtiendo {nombreDocumento} a Word...");
        }

        public void ConvertirADocumentoPDF(string nombreDocumento)
        {
            Console.WriteLine($"Convirtiendo {nombreDocumento} a PDF...");
        }

        public void ConvertirADocumentoExcel(string nombreDocumento)
        {
            Console.WriteLine($"Convirtiendo {nombreDocumento} a Excel...");
        }

        public void ConvertirADocumentoPowerPoint(string nombreDocumento)
        {
            Console.WriteLine($"Convirtiendo {nombreDocumento} a PowerPoint...");
        }

        public void ConvertirADocumentoTextoPlano(string nombreDocumento)
        {
            Console.WriteLine($"Convirtiendo {nombreDocumento} a Texto Plano...");
        }

        public void ImprimirDocumento(string nombreDocumento)
        {
            Console.WriteLine($"Imprimiendo el documento {nombreDocumento}...");
        }

        public void GuardarDocumento(string nombreDocumento)
        {
            Console.WriteLine($"Guardando el documento {nombreDocumento}...");
        }

        public void EnviarDocumentoPorCorreo(string nombreDocumento, string destinatario)
        {
            Console.WriteLine($"Enviando el documento {nombreDocumento} por correo a {destinatario}...");
        }
    }

}

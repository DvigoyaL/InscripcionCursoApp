using Fachada;
using GestorDocumentos;

namespace Controladores
{
    public class DocumentosController
    {
        private readonly SistemaFachada sistemaFachada;

        public DocumentosController()
        {
            sistemaFachada = new SistemaFachada();
        } 

        public void ImprimirDocumento(string nombreDocumento)
        {
            sistemaFachada.ImprimirDocumento(nombreDocumento);
        }

        public void GuardarDocumento(string nombreDocumento)
        {
            sistemaFachada.GuardarDocumento(nombreDocumento);
        }

        public void EnviarDocumentoPorCorreo(string nombreDocumento, string destinatario)
        {
            sistemaFachada.EnviarDocumentoPorCorreo(nombreDocumento, destinatario);
        }
    }


}

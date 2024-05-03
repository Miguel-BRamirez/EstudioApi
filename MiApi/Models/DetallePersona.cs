namespace MiApi.Models
{
    public class DetallePersona
    {
        public int idPersona { get; set; }
        public string? NombrePersona { get; set; }
        public string? CorreoUsuario { get; set; }
        public string? PasswordUsuario { get; set; }
        public bool Estado {  get; set; }
    }
}

namespace MiApi.Models
{
    public class DetallePersona
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? correo { get; set; }
        public string? password { get; set; }
        public bool Estado {  get; set; }
    }
}

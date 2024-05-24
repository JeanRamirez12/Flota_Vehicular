namespace Flota_Vehicular.Model
{
    public class Conductor
    {
        public int Id { get; set; } // Será la llave primaria
        public string Name { get; set; }
        public string? Apellido { get; set; }
        public string? Licencia { get; set; }
        public string? Telefono { get; set; }
        public string?  Direccion { get; set; }
        public ICollection<Asignacion>? Asigaciones { get; set; } // Propiedad de navegación
    }
}

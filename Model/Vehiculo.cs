namespace Flota_Vehicular.Model
{
    public class Vehiculo
    {
        public int Id { get; set; } // Será la llave primaria
        public string Placa { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Año { get; set; }
        public string? Kilometraje { get; set; }
        public ICollection<Mantenimiento>? Mantenimientos { get; set; } // Propiedad de navegación
    }
}

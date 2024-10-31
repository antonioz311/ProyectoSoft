// Models/Movimiento.cs
using System;

namespace GestionInventario.Models
{
    public class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public int ProductoId { get; set; }
        public Producto Producto { get; set; } = null!; 
        public int Cantidad { get; set; }
        public string Motivo { get; set; } = null!;
        public required string  TipoMovimiento { get; set; }  // "Ingreso" o "Salida"
    }
}

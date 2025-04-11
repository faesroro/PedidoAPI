using System;

namespace PedidoAPI.Domain.Entities;

/// <summary>
/// Representa un producto dentro de un pedido.
/// </summary>
public class Producto
    {
        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
        
        /// <summary>
        /// Precio del producto en pesos colombianos.
        /// </summary>
        public decimal Precio { get; set; }
        
        /// <summary>
        /// Cantidad solicitada del producto.
        /// </summary>
        public int Cantidad { get; set; }
    }

public class Pedido
{
    public List<Producto> Productos { get; set; } = [];
    public int Estrato { get; set; }

}

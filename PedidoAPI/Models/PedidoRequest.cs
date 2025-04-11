using System;
using PedidoAPI.Domain.Entities;

namespace PedidoAPI.Models
{
    /// <summary>
    /// Representa un pedido con una lista de productos y el estrato del cliente.
    /// </summary>
    public class PedidoRequest
    {
        /// <summary>
        /// Lista de productos incluidos en el pedido.
        /// </summary>
        public List<Producto> Productos { get; set; } = new();

        /// <summary>
        /// Estrato socioeconómico del cliente (1 a 6).
        /// </summary>
        public int Estrato { get; set; }
    }
}

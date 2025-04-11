using System;

namespace PedidoAPI.Models
{
    /// <summary>
    /// Representa la respuesta con el resumen del pedido procesado.
    /// </summary>
    public class PedidoResponse
    {
        /// <summary>
        /// Total del pedido antes de aplicar el descuento y el envío.
        /// </summary>
        public int Total { get; set; }
        
        /// <summary>
        /// Descuento aplicado al pedido, si corresponde.
        /// </summary>
        public int DescuentoAplicado { get; set; }
        
        /// <summary>
        /// Costo de envío calculado según el estrato.
        /// </summary>
        public int CostoEnvio { get; set; }
        
        /// <summary>
        /// Total del pedido incluyendo descuento y costo de envío.
        /// </summary>
        public int TotalConEnvio { get; set; }

    }
}

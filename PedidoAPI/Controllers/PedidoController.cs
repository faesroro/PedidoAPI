using Microsoft.AspNetCore.Mvc;
using PedidoAPI.Application.Services;
using PedidoAPI.Domain.Entities;
using PedidoAPI.Models;

namespace PedidoAPI.Controllers
{
    /// <summary>
    /// Controlador para procesar pedidos.
    /// </summary>
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Calcula el total del pedido incluyendo el envío y el descuento si aplica.
        /// </summary>
        /// <param name="request">El pedido con la lista de productos y el estrato del cliente.</param>
        /// <returns>El total, descuento aplicado, costo de envío y total con envío.</returns>
        /// <response code="200">Retorna el resumen del pedido procesado.</response>
        /// <response code="400">Retorna error si los datos del pedido son inválidos.</response>
        [HttpPost]
        public ActionResult<PedidoResponse> CalcularPedido([FromBody] PedidoRequest request)
        {
            // Validación de productos
            if (request.Productos == null || !request.Productos.Any())
                return BadRequest("Debe incluir al menos un producto en el pedido.");

            // Validación de estrato
            if (request.Estrato <= 0)
                return BadRequest("El estrato debe ser mayor a cero.");

            // Validación de cada producto
            foreach (var producto in request.Productos)
            {
                if (string.IsNullOrWhiteSpace(producto.Nombre))
                    return BadRequest("Cada producto debe tener un nombre.");

                if (producto.Precio <= 0)
                    return BadRequest($"El precio del producto '{producto.Nombre}' debe ser mayor a cero.");

                if (producto.Cantidad <= 0)
                    return BadRequest($"La cantidad del producto '{producto.Nombre}' debe ser mayor a cero.");
            }

            // Si todo es válido, se crea el objeto Pedido y se procesa
            var pedido = new Pedido
            {
                Productos = request.Productos,
                Estrato = request.Estrato
            };

            var resultado = _pedidoService.ProcesarPedido(pedido);
            return Ok(resultado);
        }
    }
}
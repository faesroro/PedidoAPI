using System;
using PedidoAPI.Domain.Entities;
using PedidoAPI.Models;

namespace PedidoAPI.Application.Services
{
    public class PedidoService
    {
        /// <summary>
        /// Procesa un pedido calculando el subtotal, el costo de envío y aplicando un descuento si aplica.
        /// </summary>
        /// <param name="pedido">El pedido que contiene productos y el estrato.</param>
        /// <returns>Un objeto con el resumen del pedido incluyendo totales, envío y descuentos.</returns>
        public PedidoResponse ProcesarPedido(Pedido pedido)
        {
            decimal subtotal = 0;

            foreach (var producto in pedido.Productos)
            {
                subtotal += producto.Precio * producto.Cantidad;
            }

            decimal costoEnvio = pedido.Estrato <= 2 ? 4000 : 6000;
            decimal descuento = subtotal >= 100000 ? subtotal * 0.1m : 0;
            decimal totalConEnvio = subtotal - descuento + costoEnvio;

            return new PedidoResponse
            {
                Total = (int)Math.Round(subtotal),
                DescuentoAplicado = (int)Math.Round(descuento),
                CostoEnvio = (int)Math.Round(costoEnvio),
                TotalConEnvio = (int)Math.Round(totalConEnvio)
            };
        }

        public decimal CalcularTotal(Pedido pedido)
        {
            decimal totalProductos = pedido.Productos
            .Where(p => p.Cantidad > 0)
            .Sum(p => p.Precio * p.Cantidad);

        decimal costoEnvio = totalProductos > 0
            ? pedido.Estrato switch
            {
                1 => 2.0m,
                2 => 3.0m,
                3 => 4.0m,
                _ => 5.0m,
            }
            : 0.0m;

            return totalProductos + costoEnvio;
        }

        private decimal CalcularCostoEnvio(int estrato)
        {
            return estrato switch
            {
                <= 2 => 2.0m,
                3 => 5.0m,
                _ => 10.0m
            };
        }
    }    
}

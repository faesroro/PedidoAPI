using Xunit;
using PedidoAPI.Domain.Entities;
using PedidoAPI.Application.Services;

namespace PedidoAPI.test.Test;

public class PedidoServiceTests
{
    [Fact]
    public void CalcularTotal_DeberiaRetornarSumaDePreciosPorCantidad()
    {
        // Arrange
        var pedido = new Pedido
        {
            Estrato = 2,
            Productos = new List<Producto>
            {
                new Producto { Nombre = "Arroz", Precio = 3.0m, Cantidad = 2 }, // Total: 6.0
                new Producto { Nombre = "Huevos", Precio = 5.0m, Cantidad = 1 }  // Total: 5.0
            }
        };

        var service = new PedidoService();

        // Act
        var total = service.CalcularTotal(pedido);

        // Assert
        Assert.Equal(14.0m, total); // 11.0 + 3.0 (envío estrato 2)
    }

    [Fact]
    public void CalcularTotal_PedidoSinProductos_DeberiaRetornarCero()
    {
        // Arrange
        var pedido = new Pedido
        {
            Estrato = 3,
            Productos = new List<Producto>() // vacío
        };

        var service = new PedidoService();

        // Act
        var total = service.CalcularTotal(pedido);

        // Assert
        Assert.Equal(0.0m, total);
    }

    [Fact]
    public void CalcularTotal_ProductoConCantidadCero_DeberiaIgnorarseEnElTotal()
    {
        // Arrange
        var pedido = new Pedido
        {
            Estrato = 4,
            Productos = new List<Producto>
            {
                new Producto { Nombre = "Leche", Precio = 2.5m, Cantidad = 0 }, // Total: 0
                new Producto { Nombre = "Pan", Precio = 1.5m, Cantidad = 2 }     // Total: 3.0
            }
        };

        var service = new PedidoService();

        // Act
        var total = service.CalcularTotal(pedido);

        // Assert
        Assert.Equal(8.0m, total); // 3.0 + 5.0 de envío para estrato 3
    }

    [Fact]
    public void CalcularTotal_DeberiaSumarCostoEnvio_SegunEstrato()
    {
        // Arrange: Estrato 1 → envío 2.0
        var pedido = new Pedido
        {
            Estrato = 1,
            Productos = new List<Producto>
            {
                new Producto { Nombre = "Pan", Precio = 1.5m, Cantidad = 2 } // Total: 3.0
            }
        };

        var service = new PedidoService();

        // Act
        var total = service.CalcularTotal(pedido);

        // Assert: 3.0 + 2.0 (envío) = 5.0
        Assert.Equal(5.0m, total);
    }

    
}
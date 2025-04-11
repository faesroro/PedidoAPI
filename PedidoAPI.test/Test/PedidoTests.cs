using Xunit;
using PedidoAPI.Domain.Entities;

namespace PedidoAPI.test.Test;

public class PedidoTests
{
    [Fact]
    public void CrearPedido_DeberiaContenerProductosYAsignarEstrato()
    {
        // Arrange
        var producto1 = new Producto { Nombre = "Leche", Precio = 4.5m, Cantidad = 1 };
        var producto2 = new Producto { Nombre = "Pan", Precio = 2.0m, Cantidad = 2 };

        var pedido = new Pedido
        {
            Estrato = 3,
            Productos = new List<Producto> { producto1, producto2 }
        };

        // Assert
        Assert.Equal(3, pedido.Estrato);
        Assert.Equal(2, pedido.Productos.Count);
        Assert.Equal("Leche", pedido.Productos[0].Nombre);
        Assert.Equal("Pan", pedido.Productos[1].Nombre);
    }

    [Fact]
    public void Pedido_DeberiaInicializarseConProductosYEstrato()
    {
        // Arrange
        var productos = new List<Producto>
        {
            new Producto { Nombre = "Pan", Precio = 2.0m, Cantidad = 3 },
            new Producto { Nombre = "Leche", Precio = 4.5m, Cantidad = 1 }
        };

        var pedido = new Pedido
        {
            Estrato = 3,
            Productos = productos
        };

        // Act & Assert
        Assert.Equal(3, pedido.Estrato);
        Assert.Equal(2, pedido.Productos.Count);
        Assert.Equal("Pan", pedido.Productos[0].Nombre);
        Assert.Equal(4.5m, pedido.Productos[1].Precio);
    }
}
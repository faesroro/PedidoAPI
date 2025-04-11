using Xunit;
using PedidoAPI.Domain.Entities;

namespace PedidoAPI.test.Test;

public class ProductoTests
{
     [Fact]
    public void CrearProducto_DeberiaAsignarValoresCorrectamente()
    {
        // Arrange
        var producto = new Producto
        {
            Nombre = "Pan",
            Precio = 2.5m,
            Cantidad = 3
        };

        // Assert
        Assert.Equal("Pan", producto.Nombre);
        Assert.Equal(2.5m, producto.Precio);
        Assert.Equal(3, producto.Cantidad);
    }

    [Fact]
    public void Producto_DeberiaAsignarNombrePrecioCantidadCorrectamente()
    {
        // Arrange
        var producto = new Producto
        {
            Nombre = "Café",
            Precio = 10.5m,
            Cantidad = 2
        };

        // Act & Assert
        Assert.Equal("Café", producto.Nombre);
        Assert.Equal(10.5m, producto.Precio);
        Assert.Equal(2, producto.Cantidad);
    }    
}
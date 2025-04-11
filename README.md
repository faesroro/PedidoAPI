# 📦 PedidoAPI

**PedidoAPI** es una API REST desarrollada en .NET 8 que permite calcular el total de un pedido con base en una lista de productos. Aplica reglas de negocio como descuentos y cargos de envío dependiendo del estrato socioeconómico.

---

##  Funcionalidad principal

- Recibe un payload JSON con una lista de productos (precio, cantidad).
- Calcula el subtotal del pedido.
- Aplica un descuento del 10% si el subtotal supera los 100.000.
- Cobra un costo de envío:
  - $4.000 si el estrato es 1 o 2.
  - $6.000 para los demás estratos.
- Devuelve el total con envío, el descuento aplicado y el detalle.

---

##  Estructura del proyecto

```
PedidoAPI/
├── PedidoAPI/                 # Proyecto principal (.NET 8 Web API)
│   ├── Controllers/           # Controlador principal de la API
│   ├── Domain/                # Entidades del dominio (Producto, Pedido)
│   ├── Application/           # Lógica de negocio (PedidoService)
│   ├── Program.cs             # Configuración de la app y Swagger
│   └── PedidoAPI.csproj
│
├── PedidoAPI.test/           # Proyecto de pruebas unitarias
│   ├── Test/                  # Casos de prueba de PedidoService
│   └── PedidoAPI.test.csproj
│
└── README.md                  # Documentación del proyecto
```

---

##  Pruebas unitarias

Se utilizan pruebas con xUnit para validar la lógica de cálculo:

- Total correcto con múltiples productos.
- Ignorar productos con cantidad 0.
- Pedido vacío retorna total 0.
- Aplicación de descuentos según el subtotal.
- Costo de envío basado en el estrato.

### Ejecutar pruebas

Desde la raíz del proyecto:

```bash
dotnet test
```

---

##  Documentación interactiva (Swagger)

La API expone su documentación automática en Swagger.

### Acceder a Swagger

Una vez ejecutada la app:

📍 URL: `http://localhost:5136/swagger`

---

##  Cómo ejecutar

1. Clona el repositorio o descarga el ZIP.
2. Abre la solución en Visual Studio o VS Code.
3. Ejecuta el proyecto principal:

```bash
cd PedidoAPI
dotnet run
```

4. Ve a [http://localhost:5136/swagger](http://localhost:5136/swagger)

---

##  Ejemplo de request

```json
POST /api/pedido
Content-Type: application/json

{
  "estrato": 3,
  "productos": [
    { "nombre": "Producto A", "precio": 30000, "cantidad": 2 },
    { "nombre": "Producto B", "precio": 20000, "cantidad": 1 }
  ]
}
```

### Respuesta esperada

```json
{
  "total": 80000,
  "descuentoAplicado": 0,
  "costoEnvio": 6000,
  "totalConEnvio": 86000
}
```

---

##  Validaciones

- El nombre del producto no puede estar vacío.
- El precio debe ser mayor a 0.
- La cantidad debe ser mayor a 0.
- El estrato debe estar entre 1 y 6.

Las respuestas inválidas devuelven un código 400 con detalles del error.

---

##  Licencia

Este proyecto es solo para fines educativos y de evaluación técnica.

---

## Autor

** Fabian Esteban Rojas Rozo **  
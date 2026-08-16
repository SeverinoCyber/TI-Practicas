class Producto:
    def __init__(self, nombre, precio, stock):
        self.nombre = nombre
        self.precio = precio
        self.stock = stock

class Inventario:
    def __init__(self):
        self.productos = []

    def agregar_producto(self, producto):
        self.productos.append(producto)

    def calcular_valor_total(self):
        return sum(p.precio * p.stock for p in self.productos)

    def mostrar(self):
        for p in self.productos:
            print(f"- {p.nombre}: ${p.precio} (Stock: {p.stock})")

inv = Inventario()
inv.agregar_producto(Producto("Laptop", 800.0, 5))
inv.agregar_producto(Producto("Mouse", 20.0, 15))

print("--- INVENTARIO ---")
inv.mostrar()
print(f"Valor total del inventario: ${inv.calcular_valor_total()}")
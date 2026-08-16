class Producto {
    constructor(nombre, precio, stock) {
        this.nombre = nombre;
        this.precio = precio;
        this.stock = stock;
    }
}

class Inventario {
    constructor() {
        this.productos = [];
    }

    agregar(producto) {
        this.productos.push(producto);
    }

    calcularTotal() {
        return this.productos.reduce((acc, p) => acc + (p.precio * p.stock), 0);
    }

    mostrar() {
        this.productos.forEach(p => console.log(`- ${p.nombre}: $${p.precio} (Stock: ${p.stock})`));
    }
}

const inv = new Inventario();
inv.agregar(new Producto("Laptop", 800.0, 5));
inv.agregar(new Producto("Mouse", 20.0, 15));

console.log("--- INVENTARIO ---");
inv.mostrar();
console.log(`Valor total del inventario: $${inv.calcularTotal()}`);
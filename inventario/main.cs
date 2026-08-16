using System;
using System.Collections.Generic;
using System.Linq;

class Producto {
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }

    public Producto(string nombre, double precio, int stock) {
        Nombre = nombre; Precio = precio; Stock = stock;
    }
}

class Inventario {
    private List<Producto> productos = new List<Producto>();

    public void Agregar(Producto p) => productos.Add(p);
    public double CalcularTotal() => productos.Sum(p => p.Precio * p.Stock);

    public void Mostrar() {
        foreach (var p in productos)
            Console.WriteLine($"- {p.Nombre}: ${p.Precio} (Stock: {p.Stock})");
    }
}

class Program {
    static void Main() {
        var inv = new Inventario();
        inv.Agregar(new Producto("Laptop", 800.0, 5));
        inv.Agregar(new Producto("Mouse", 20.0, 15));

        Console.WriteLine("--- INVENTARIO ---");
        inv.Mostrar();
        Console.WriteLine($"Valor total del inventario: ${inv.CalcularTotal()}");
    }
}
import java.util.ArrayList;
import java.util.List;

class Producto {
    String nombre;
    double precio;
    int stock;

    public Producto(String nombre, double precio, int stock) {
        this.nombre = nombre;
        this.precio = precio;
        this.stock = stock;
    }
}

class Inventario {
    private List<Producto> productos = new ArrayList<>();

    public void agregar(Producto p) { productos.add(p); }

    public double calcularTotal() {
        double total = 0;
        for (Producto p : productos) total += p.precio * p.stock;
        return total;
    }

    public void mostrar() {
        for (Producto p : productos)
            System.out.println("- " + p.nombre + ": $" + p.precio + " (Stock: " + p.stock + ")");
    }
}

public class Main {
    public static void main(String[] args) {
        Inventario inv = new Inventario();
        inv.agregar(new Producto("Laptop", 800.0, 5));
        inv.agregar(new Producto("Mouse", 20.0, 15));

        System.out.println("--- INVENTARIO ---");
        inv.mostrar();
        System.out.println("Valor total del inventario: $" + inv.calcularTotal());
    }
}
#include <iostream>
#include <vector>
#include <string>

class Producto {
public:
    std::string nombre;
    double precio;
    int stock;

    Producto(std::string n, double p, int s) : nombre(n), precio(p), stock(s) {}
};

class Inventario {
private:
    std::vector<Producto> productos;
public:
    void agregar(const Producto& p) { productos.push_back(p); }

    double calcularTotal() {
        double total = 0;
        for (const auto& p : productos) total += p.precio * p.stock;
        return total;
    }

    void mostrar() {
        for (const auto& p : productos)
            std::cout << "- " << p.nombre << ": $" << p.precio << " (Stock: " << p.stock << ")\n";
    }
};

int main() {
    Inventario inv;
    inv.agregar(Producto("Laptop", 800.0, 5));
    inv.agregar(Producto("Mouse", 20.0, 15));

    std::cout << "--- INVENTARIO ---\n";
    inv.mostrar();
    std::cout << "Valor total del inventario: $" << inv.calcularTotal() << "\n";
    return 0;
}
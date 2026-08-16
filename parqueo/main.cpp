#include <iostream>
#include <vector>
#include <string>

class Vehiculo {
public:
    std::string placa;
    std::string tipo;

    Vehiculo(std::string p, std::string t) : placa(p), tipo(t) {}
};

class Parqueo {
private:
    int capacidadMaxima;
    std::vector<Vehiculo> vehiculosEstacionados;

public:
    Parqueo(int capacidad) : capacidadMaxima(capacidad) {}

    void estacionar(const Vehiculo& vehiculo) {
        if (vehiculosEstacionados.size() < capacidadMaxima) {
            vehiculosEstacionados.push_back(vehiculo);
        } else {
            std::cout << "El vehiculo no se pudo agregar porque el parqueo esta lleno.\n";
        }
    }

    void retirar(const std::string& placa) {
        for (auto it = vehiculosEstacionados.begin(); it != vehiculosEstacionados.end(); ++it) {
            if (it->placa == placa) {
                vehiculosEstacionados.erase(it);
                std::cout << "Vehículo con placa " << placa << " ha salido del parqueo.\n";
                return;
            }
        }
        std::cout << "No se encontró ningún vehículo con la placa " << placa << ".\n";
    }

    void mostrarEstado() const {
        std::cout << "Hay total de " << vehiculosEstacionados.size() << " / " << capacidadMaxima << " espacios ocupados.\n";
        for (const auto& v : vehiculosEstacionados) {
            std::cout << "- Placa: " << v.placa << " | Tipo: " << v.tipo << "\n";
        }
    }
};

int main() {
    Parqueo parqueo(3);
    Vehiculo parqueo1("AJSDAJDKA", "Automovil");
    Vehiculo parqueo2("AJSDVNSKA", "Moto");
    Vehiculo parqueo3("AJSDAKLSJ", "Camion");
    Vehiculo parqueo4("AKLVCMBLG", "Automovil");

    parqueo.estacionar(parqueo1);
    parqueo.estacionar(parqueo2);
    parqueo.estacionar(parqueo3);
    parqueo.estacionar(parqueo4);

    parqueo.mostrarEstado();
    parqueo.retirar("AJSDVNSKA");
    parqueo.mostrarEstado();

    return 0;
}
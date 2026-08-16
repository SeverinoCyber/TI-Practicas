#include <iostream>
#include <vector>
#include <numeric>
#include <string>

class Estudiante {
public:
    std::string nombre;
    std::string matricula;
    std::vector<double> calificaciones;

    Estudiante(std::string n, std::string m) : nombre(n), matricula(m) {}

    void agregarCalificacion(double nota) { calificaciones.push_back(nota); }

    double calcularPromedio() const {
        if (calificaciones.empty()) return 0.0;
        double suma = std::accumulate(calificaciones.begin(), calificaciones.end(), 0.0);
        return suma / calificaciones.size();
    }

    bool haAprobado() const { return calcularPromedio() >= 70.0; }
};

int main() {
    Estudiante est("Carlos Pérez", "2026-001");
    est.agregarCalificacion(85.0);
    est.agregarCalificacion(90.0);
    est.agregarCalificacion(65.0);

    double promedio = est.calcularPromedio();
    std::string estado = est.haAprobado() ? "Aprobado" : "Reprobado";
    std::cout << "Estudiante: " << est.nombre << " | Promedio: " << promedio << " | Estado: " << estado << "\n";
    return 0;
}
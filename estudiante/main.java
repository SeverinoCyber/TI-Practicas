import java.util.ArrayList;
import java.util.List;

class Estudiante {
    String nombre;
    String matricula;
    private List<Double> calificaciones = new ArrayList<>();

    public Estudiante(String nombre, String matricula) {
        this.nombre = nombre;
        this.matricula = matricula;
    }

    public void agregarCalificacion(double nota) { calificaciones.add(nota); }

    public double calcularPromedio() {
        if (calificaciones.isEmpty()) return 0.0;
        double suma = 0;
        for (double nota : calificaciones) suma += nota;
        return suma / calificaciones.size();
    }

    public boolean haAprobado() { return calcularPromedio() >= 70.0; }
}

public class Main {
    public static void main(String[] args) {
        Estudiante est = new Estudiante("Carlos Pérez", "2026-001");
        est.agregarCalificacion(85.0);
        est.agregarCalificacion(90.0);
        est.agregarCalificacion(65.0);

        double promedio = est.calcularPromedio();
        String estado = est.haAprobado() ? "Aprobado" : "Reprobado";
        System.out.printf("Estudiante: %s | Promedio: %.2f | Estado: %s\n", est.nombre, promedio, estado);
    }
}
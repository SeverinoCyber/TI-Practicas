using System;
using System.Collections.Generic;
using System.Linq;

class Estudiante {
    public string Nombre { get; set; }
    public string Matricula { get; set; }
    private List<double> calificaciones = new List<double>();

    public Estudiante(string nombre, string matricula) {
        Nombre = nombre; Matricula = matricula;
    }

    public void AgregarCalificacion(double nota) => calificaciones.Add(nota);
    public double CalcularPromedio() => calificaciones.Count == 0 ? 0 : calificaciones.Average();
    public bool HaAprobado() => CalcularPromedio() >= 70.0;
}

class Program {
    static void Main() {
        var est = new Estudiante("Carlos Pérez", "2026-001");
        est.AgregarCalificacion(85.0);
        est.AgregarCalificacion(90.0);
        est.AgregarCalificacion(65.0);

        double promedio = est.CalcularPromedio();
        string estado = est.HaAprobado() ? "Aprobado" : "Reprobado";
        Console.WriteLine($"Estudiante: {est.Nombre} | Promedio: {promedio:F2} | Estado: {estado}");
    }
}
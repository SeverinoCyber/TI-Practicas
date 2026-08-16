class Estudiante {
    constructor(nombre, matricula) {
        this.nombre = nombre;
        this.matricula = matricula;
        this.calificaciones = [];
    }

    agregarCalificacion(nota) {
        this.calificaciones.push(nota);
    }

    calcularPromedio() {
        if (this.calificaciones.length === 0) return 0;
        const suma = this.calificaciones.reduce((a, b) => a + b, 0);
        return suma / this.calificaciones.length;
    }

    haAprobado() {
        return this.calcularPromedio() >= 70.0;
    }
}

const est = new Estudiante("Carlos Pérez", "2026-001");
est.agregarCalificacion(85.0);
est.agregarCalificacion(90.0);
est.agregarCalificacion(65.0);

const promedio = est.calcularPromedio();
const estado = est.haAprobado() ? "Aprobado" : "Reprobado";
console.log(`Estudiante: ${est.nombre} | Promedio: ${promedio.toFixed(2)} | Estado: ${estado}`);
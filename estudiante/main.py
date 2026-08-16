class Estudiante:
    def __init__(self, nombre, matricula):
        self.nombre = nombre
        self.matricula = matricula
        self.calificaciones = []

    def agregar_calificacion(self, nota):
        self.calificaciones.append(nota)

    def calcular_promedio(self):
        if not self.calificaciones:
            return 0.0
        return sum(self.calificaciones) / len(self.calificaciones)

    def ha_aprobado(self):
        return self.calcular_promedio() >= 70.0

est = Estudiante("Carlos Pérez", "2026-001")
est.agregar_calificacion(85.0)
est.agregar_calificacion(90.0)
est.agregar_calificacion(65.0)

promedio = est.calcular_promedio()
estado = "Aprobado" if est.ha_aprobado() else "Reprobado"
print(f"Estudiante: {est.nombre} | Promedio: {promedio:.2f} | Estado: {estado}")
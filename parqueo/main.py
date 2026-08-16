
class Vehiculo:
    def __init__(self, placa, tipo):
        self.placa = placa
        self.tipo = tipo

class Parqueo:
    def __init__(self, capacidad_maxima):
        self.capacidad_maxima = capacidad_maxima
        self.vehiculos_estacionados = []

    def estacionar(self, vehiculo):
        if len(self.vehiculos_estacionados) < self.capacidad_maxima:
            self.vehiculos_estacionados.append(vehiculo)
        else:
            print("El vehiculo no se pudo agregar porque el parqueo esta lleno.")
    
    def retirar(self, placa):
        for vehiculo in self.vehiculos_estacionados:
            if vehiculo.placa == placa:
                self.vehiculos_estacionados.remove(vehiculo)
                print(f"Vehículo con placa {placa} ha salido del parqueo.")
                return
        print(f"No se encontró ningún vehículo con la placa {placa}.")

    def mostrar_estado(self):
        print(f"Hay total de {len(self.vehiculos_estacionados)} / {self.capacidad_maxima} espacios ocupados.")

        for v in self.vehiculos_estacionados:
            print(f"- Placa: {v.placa} | Tipo: {v.tipo}")



parqueo = Parqueo(3)
parqueo1 = Vehiculo("AJSDAJDKA", "Automovil")
parqueo2 = Vehiculo("AJSDVNSKA", "Moto")
parqueo3 = Vehiculo("AJSDAKLSJ", "Camion")
parqueo4 = Vehiculo("AKLVCMBLG", "Automovil")

parqueo.estacionar(parqueo1)
parqueo.estacionar(parqueo2)
parqueo.estacionar(parqueo3)
parqueo.estacionar(parqueo4)
parqueo.mostrar_estado()
parqueo.retirar("AJSDVNSKA")
parqueo.mostrar_estado()
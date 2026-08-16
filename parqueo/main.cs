using System;
using System.Collections.Generic;

class Vehiculo {
    public string Placa { get; set; }
    public string Tipo { get; set; }

    public Vehiculo(string placa, string tipo) {
        Placa = placa;
        Tipo = tipo;
    }
}

class Parqueo {
    public int CapacidadMaxima { get; set; }
    private List<Vehiculo> vehiculosEstacionados = new List<Vehiculo>();

    public Parqueo(int capacidadMaxima) {
        CapacidadMaxima = capacidadMaxima;
    }

    public void Estacionar(Vehiculo vehiculo) {
        if (vehiculosEstacionados.Count < CapacidadMaxima) {
            vehiculosEstacionados.Add(vehiculo);
        } else {
            Console.WriteLine("El vehiculo no se pudo agregar porque el parqueo esta lleno.");
        }
    }

    public void Retirar(string placa) {
        foreach (var vehiculo in vehiculosEstacionados) {
            if (vehiculo.Placa == placa) {
                vehiculosEstacionados.Remove(vehiculo);
                Console.WriteLine($"Vehículo con placa {placa} ha salido del parqueo.");
                return;
            }
        }
        Console.WriteLine($"No se encontró ningún vehículo con la placa {placa}.");
    }

    public void MostrarEstado() {
        Console.WriteLine($"Hay total de {vehiculosEstacionados.Count} / {CapacidadMaxima} espacios ocupados.");
        foreach (var v in vehiculosEstacionados) {
            Console.WriteLine($"- Placa: {v.Placa} | Tipo: {v.Tipo}");
        }
    }
}

class Program {
    static void Main() {
        var parqueo = new Parqueo(3);
        var parqueo1 = new Vehiculo("AJSDAJDKA", "Automovil");
        var parqueo2 = new Vehiculo("AJSDVNSKA", "Moto");
        var parqueo3 = new Vehiculo("AJSDAKLSJ", "Camion");
        var parqueo4 = new Vehiculo("AKLVCMBLG", "Automovil");

        parqueo.Estacionar(parqueo1);
        parqueo.Estacionar(parqueo2);
        parqueo.Estacionar(parqueo3);
        parqueo.Estacionar(parqueo4);

        parqueo.MostrarEstado();
        parqueo.Retirar("AJSDVNSKA");
        parqueo.MostrarEstado();
    }
}
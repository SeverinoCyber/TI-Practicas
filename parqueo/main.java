import java.util.ArrayList;
import java.util.List;

class Vehiculo {
    String placa;
    String tipo;

    public Vehiculo(String placa, String tipo) {
        this.placa = placa;
        this.tipo = tipo;
    }
}

class Parqueo {
    int capacidadMaxima;
    List<Vehiculo> vehiculosEstacionados = new ArrayList<>();

    public Parqueo(int capacidadMaxima) {
        this.capacidadMaxima = capacidadMaxima;
    }

    public void estacionar(Vehiculo vehiculo) {
        if (vehiculosEstacionados.size() < capacidadMaxima) {
            vehiculosEstacionados.add(vehiculo);
        } else {
            System.out.println("El vehiculo no se pudo agregar porque el parqueo esta lleno.");
        }
    }

    public void retirar(String placa) {
        for (Vehiculo vehiculo : vehiculosEstacionados) {
            if (vehiculo.placa.equals(placa)) {
                vehiculosEstacionados.remove(vehiculo);
                System.out.println("Vehículo con placa " + placa + " ha salido del parqueo.");
                return;
            }
        }
        System.out.println("No se encontró ningún vehículo con la placa " + placa + ".");
    }

    public void mostrarEstado() {
        System.out.println("Hay total de " + vehiculosEstacionados.size() + " / " + capacidadMaxima + " espacios ocupados.");
        for (Vehiculo v : vehiculosEstacionados) {
            System.out.println("- Placa: " + v.placa + " | Tipo: " + v.tipo);
        }
    }
}

public class Main {
    public static void main(String[] args) {
        Parqueo parqueo = new Parqueo(3);
        Vehiculo parqueo1 = new Vehiculo("AJSDAJDKA", "Automovil");
        Vehiculo parqueo2 = new Vehiculo("AJSDVNSKA", "Moto");
        Vehiculo parqueo3 = new Vehiculo("AJSDAKLSJ", "Camion");
        Vehiculo parqueo4 = new Vehiculo("AKLVCMBLG", "Automovil");

        parqueo.estacionar(parqueo1);
        parqueo.estacionar(parqueo2);
        parqueo.estacionar(parqueo3);
        parqueo.estacionar(parqueo4);

        parqueo.mostrarEstado();
        parqueo.retirar("AJSDVNSKA");
        parqueo.mostrarEstado();
    }
}
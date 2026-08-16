class Vehiculo {
    constructor(placa, tipo) {
        this.placa = placa;
        this.tipo = tipo;
    }
}

class Parqueo {
    constructor(capacidadMaxima) {
        this.capacidadMaxima = capacidadMaxima;
        this.vehiculosEstacionados = [];
    }

    estacionar(vehiculo) {
        if (this.vehiculosEstacionados.length < this.capacidadMaxima) {
            this.vehiculosEstacionados.push(vehiculo);
        } else {
            console.log("El vehiculo no se pudo agregar porque el parqueo esta lleno.");
        }
    }

    retirar(placa) {
        for (let i = 0; i < this.vehiculosEstacionados.length; i++) {
            if (this.vehiculosEstacionados[i].placa === placa) {
                this.vehiculosEstacionados.splice(i, 1);
                console.log(`Vehículo con placa ${placa} ha salido del parqueo.`);
                return;
            }
        }
        console.log(`No se encontró ningún vehículo con la placa ${placa}.`);
    }

    mostrarEstado() {
        console.log(`Hay total de ${this.vehiculosEstacionados.length} / ${this.capacidadMaxima} espacios ocupados.`);
        for (const v of this.vehiculosEstacionados) {
            console.log(`- Placa: ${v.placa} | Tipo: ${v.tipo}`);
        }
    }
}

const parqueo = new Parqueo(3);
const parqueo1 = new Vehiculo("AJSDAJDKA", "Automovil");
const parqueo2 = new Vehiculo("AJSDVNSKA", "Moto");
const parqueo3 = new Vehiculo("AJSDAKLSJ", "Camion");
const parqueo4 = new Vehiculo("AKLVCMBLG", "Automovil");

parqueo.estacionar(parqueo1);
parqueo.estacionar(parqueo2);
parqueo.estacionar(parqueo3);
parqueo.estacionar(parqueo4);

parqueo.mostrarEstado();
parqueo.retirar("AJSDVNSKA");
parqueo.mostrarEstado();
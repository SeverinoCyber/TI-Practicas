class Personaje {
    constructor(nombre, hp, ataque) {
        this.nombre = nombre;
        this.hp = hp;
        this.ataque = ataque;
    }

    atacar(objetivo) {
        objetivo.hp -= this.ataque;
        console.log(`${this.nombre} ataca a ${objetivo.nombre} infligiendo ${this.ataque} de daño.`);
    }

    estaVivo() {
        return this.hp > 0;
    }
}

class Guerrero extends Personaje {}
class Mago extends Personaje {}

const jugador = new Guerrero("Aragorn", 100, 20);
const enemigo = new Mago("Gandalf Oscuro", 80, 25);

while (jugador.estaVivo() && enemigo.estaVivo()) {
    jugador.atacar(enemigo);
    if (enemigo.estaVivo()) enemigo.atacar(jugador);
}

const ganador = jugador.estaVivo() ? jugador.nombre : enemigo.nombre;
console.log(`¡El ganador del combate es ${ganador}!`);
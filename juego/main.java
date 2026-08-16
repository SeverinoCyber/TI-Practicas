class Personaje {
    protected String nombre;
    protected int hp;
    protected int ataque;

    public Personaje(String nombre, int hp, int ataque) {
        this.nombre = nombre;
        this.hp = hp;
        this.ataque = ataque;
    }

    public void atacar(Personaje objetivo) {
        objetivo.hp -= this.ataque;
        System.out.println(nombre + " ataca a " + objetivo.nombre + " infligiendo " + ataque + " de daño.");
    }

    public boolean estaVivo() { return hp > 0; }
}

class Guerrero extends Personaje {
    public Guerrero(String nombre, int hp, int ataque) { super(nombre, hp, ataque); }
}

class Mago extends Personaje {
    public Mago(String nombre, int hp, int ataque) { super(nombre, hp, ataque); }
}

public class Main {
    public static void main(String[] args) {
        Guerrero jugador = new Guerrero("Aragorn", 100, 20);
        Mago enemigo = new Mago("Gandalf Oscuro", 80, 25);

        while (jugador.estaVivo() && enemigo.estaVivo()) {
            jugador.atacar(enemigo);
            if (enemigo.estaVivo()) enemigo.atacar(jugador);
        }

        String ganador = jugador.estaVivo() ? jugador.nombre : enemigo.nombre;
        System.out.println("¡El ganador del combate es " + ganador + "!");
    }
}
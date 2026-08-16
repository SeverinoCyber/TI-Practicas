using System;

class Personaje {
    public string Nombre { get; set; }
    public int HP { get; set; }
    public int Ataque { get; set; }

    public Personaje(string nombre, int hp, int ataque) {
        Nombre = nombre;
        HP = hp;
        Ataque = ataque;
    }

    public virtual void Atacar(Personaje objetivo) {
        objetivo.HP -= Ataque;
        Console.WriteLine($"{Nombre} ataca a {objetivo.Nombre} infligiendo {Ataque} de daño.");
    }

    public bool EstaVivo() => HP > 0;
}

class Guerrero : Personaje {
    public Guerrero(string nombre, int hp, int ataque) : base(nombre, hp, ataque) {}
}

class Mago : Personaje {
    public Mago(string nombre, int hp, int ataque) : base(nombre, hp, ataque) {}
}

class Program {
    static void Main() {
        var jugador = new Guerrero("Aragorn", 100, 20);
        var enemigo = new Mago("Gandalf Oscuro", 80, 25);

        while (jugador.EstaVivo() && enemigo.EstaVivo()) {
            jugador.Atacar(enemigo);
            if (enemigo.EstaVivo()) enemigo.Atacar(jugador);
        }

        string ganador = jugador.EstaVivo() ? jugador.Nombre : enemigo.Nombre;
        Console.WriteLine($"¡El ganador del combate es {ganador}!");
    }
}
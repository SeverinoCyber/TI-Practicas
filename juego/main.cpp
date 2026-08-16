#include <iostream>
#include <string>

class Personaje {
public:
    std::string nombre;
    int hp;
    int ataque;

    Personaje(std::string n, int h, int a) : nombre(n), hp(h), ataque(a) {}

    virtual void atacar(Personaje& objetivo) {
        objetivo.hp -= ataque;
        std::cout << nombre << " ataca a " << objetivo.nombre << " infligiendo " << ataque << " de daño.\n";
    }

    bool estaVivo() const { return hp > 0; }
};

class Guerrero : public Personaje {
public:
    Guerrero(std::string n, int h, int a) : Personaje(n, h, a) {}
};

class Mago : public Personaje {
public:
    Mago(std::string n, int h, int a) : Personaje(n, h, a) {}
};

int main() {
    Guerrero jugador("Aragorn", 100, 20);
    Mago enemigo("Gandalf Oscuro", 80, 25);

    while (jugador.estaVivo() && enemigo.estaVivo()) {
        jugador.atacar(enemigo);
        if (enemigo.estaVivo()) enemigo.atacar(jugador);
    }

    std::string ganador = jugador.estaVivo() ? jugador.nombre : enemigo.nombre;
    std::cout << "¡El ganador del combate es " << ganador << "!\n";
    return 0;
}
class Personaje:
    def __init__(self, nombre, hp, ataque):
        self.nombre = nombre
        self.hp = hp
        self.ataque = ataque

    def atacar(self, objetivo):
        objetivo.hp -= self.ataque
        print(f"{self.nombre} ataca a {objetivo.nombre} infligiendo {self.ataque} de daño.")

    def esta_vivo(self):
        return self.hp > 0

class Guerrero(Personaje):
    def __init__(self, nombre, hp, ataque):
        super().__init__(nombre, hp, ataque)

class Mago(Personaje):
    def __init__(self, nombre, hp, ataque):
        super().__init__(nombre, hp, ataque)

# Flujo principal
jugador = Guerrero("Aragorn", 100, 20)
enemigo = Mago("Gandalf Oscuro", 80, 25)

while jugador.esta_vivo() and enemigo.esta_vivo():
    jugador.atacar(enemigo)
    if enemigo.esta_vivo():
        enemigo.atacar(jugador)

ganador = jugador.nombre if jugador.esta_vivo() else enemigo.nombre
print(f"¡El ganador del combate es {ganador}!")
class CuentaBancaria {
    #saldo; // Campo privado en sintaxis moderna JS

    constructor(titular, saldoInicial) {
        this.titular = titular;
        this.#saldo = saldoInicial;
    }

    depositar(monto) {
        if (monto > 0) {
            this.#saldo += monto;
            console.log(`Depósito de $${monto} exitoso.`);
        }
    }

    retirar(monto) {
        if (monto > 0 && monto <= this.#saldo) {
            this.#saldo -= monto;
            console.log(`Retiro de $${monto} exitoso.`);
        } else {
            console.log("Fondos insuficientes o monto inválido.");
        }
    }

    consultarSaldo() {
        return this.#saldo;
    }
}

const cuenta = new CuentaBancaria("Ana Gómez", 500.0);
cuenta.depositar(200.0);
cuenta.retirar(100.0);
cuenta.retirar(800.0); // Falla
console.log(`Saldo final de ${cuenta.titular}: $${cuenta.consultarSaldo()}`);
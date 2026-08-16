#include <iostream>
#include <string>

class CuentaBancaria {
private:
    std::string titular;
    double saldo;

public:
    CuentaBancaria(std::string t, double s) : titular(t), saldo(s) {}

    void depositar(double monto) {
        if (monto > 0) {
            saldo += monto;
            std::cout << "Depósito de $" << monto << " exitoso.\n";
        }
    }

    void retirar(double monto) {
        if (monto > 0 && monto <= saldo) {
            saldo -= monto;
            std::cout << "Retiro de $" << monto << " exitoso.\n";
        } else {
            std::cout << "Fondos insuficientes o monto inválido.\n";
        }
    }

    double consultarSaldo() const { return saldo; }
    std::string getTitular() const { return titular; }
};

int main() {
    CuentaBancaria cuenta("Ana Gómez", 500.0);
    cuenta.depositar(200.0);
    cuenta.retirar(100.0);
    cuenta.retirar(800.0); // Falla
    std::cout << "Saldo final de " << cuenta.getTitular() << ": $" << cuenta.consultarSaldo() << "\n";
    return 0;
}
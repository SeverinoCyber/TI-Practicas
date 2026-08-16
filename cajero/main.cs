using System;

class CuentaBancaria {
    public string Titular { get; private set; }
    private double saldo;

    public CuentaBancaria(string titular, double saldoInicial) {
        Titular = titular;
        saldo = saldoInicial;
    }

    public void Depositar(double monto) {
        if (monto > 0) {
            saldo += monto;
            Console.WriteLine($"Depósito de ${monto} exitoso.");
        }
    }

    public void Retirar(double monto) {
        if (monto > 0 && monto <= saldo) {
            saldo -= monto;
            Console.WriteLine($"Retiro de ${monto} exitoso.");
        } else {
            Console.WriteLine("Fondos insuficientes o monto inválido.");
        }
    }

    public double ConsultarSaldo() => saldo;
}

class Program {
    static void Main() {
        var cuenta = new CuentaBancaria("Ana Gómez", 500.0);
        cuenta.Depositar(200.0);
        cuenta.Retirar(100.0);
        cuenta.Retirar(800.0); // Falla
        Console.WriteLine($"Saldo final de {cuenta.Titular}: ${cuenta.ConsultarSaldo()}");
    }
}
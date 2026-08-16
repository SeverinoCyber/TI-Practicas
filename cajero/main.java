class CuentaBancaria {
    private String titular;
    private double saldo;

    public CuentaBancaria(String titular, double saldoInicial) {
        this.titular = titular;
        this.saldo = saldoInicial;
    }

    public void depositar(double monto) {
        if (monto > 0) {
            saldo += monto;
            System.out.println("Depósito de $" + monto + " exitoso.");
        }
    }

    public void retirar(double monto) {
        if (monto > 0 && monto <= saldo) {
            saldo -= monto;
            System.out.println("Retiro de $" + monto + " exitoso.");
        } else {
            System.out.println("Fondos insuficientes o monto inválido.");
        }
    }

    public double consultarSaldo() { return saldo; }
    public String getTitular() { return titular; }
}

public class Main {
    public static void main(String[] args) {
        CuentaBancaria cuenta = new CuentaBancaria("Ana Gómez", 500.0);
        cuenta.depositar(200.0);
        cuenta.retirar(100.0);
        cuenta.retirar(800.0); // Falla
        System.out.println("Saldo final de " + cuenta.getTitular() + ": $" + cuenta.consultarSaldo());
    }
}
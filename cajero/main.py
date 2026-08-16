class CuentaBancaria:
    def __init__(self, titular, saldo_inicial):
        self.titular = titular
        self._saldo = saldo_inicial  # Atributo privado/protegido

    def depositar(self, monto):
        if monto > 0:
            self._saldo += monto
            print(f"Depósito de ${monto} exitoso.")

    def retirar(self, monto):
        if 0 < monto <= self._saldo:
            self._saldo -= monto
            print(f"Retiro de ${monto} exitoso.")
        else:
            print("Fondos insuficientes o monto inválido.")

    def consultar_saldo(self):
        return self._saldo

cuenta = CuentaBancaria("Ana Gómez", 500.0)
cuenta.depositar(200.0)
cuenta.retirar(100.0)
cuenta.retirar(800.0)  # Falla
print(f"Saldo final de {cuenta.titular}: ${cuenta.consultar_saldo()}")
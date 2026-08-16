using System;

// 1. ABSTRACCIÓN: Clase base de la que no se pueden crear objetos directamente
public abstract class Animal
{
    public string Nombre { get; set; }

    // 2. ENCAPSULAMIENTO: Variable privada y protegida
    private int edad;
    public void SetEdad(int e) { if (e > 0) edad = e;}  // Validación simple

    public Animal(string nombre) => Nombre = nombre;

    // Método abstracto que obliga a definir el sonido
    public abstract void HacerSonido(); 

    public int GetEdad() 
    {
        return edad;
    }

    public void MostrarDatos()
    {
        Console.WriteLine($"Nombre: {Nombre} | Edad: {edad} años.");
    }
}

// 3. HERENCIA: Perro hereda de Animal
public class Perro : Animal
{
    public Perro(string nombre) : base(nombre) { }
    // 4. POLIMORFISMO: Define su propio sonido
    public override void HacerSonido() => Console.WriteLine($"{Nombre} dice: ¡Guau!");
}

class Program
{
    static void Main()
    {
        // Uso de los 4 pilares
        Perro miPerro = new Perro("Max");
        miPerro.SetEdad(3);        // Encapsulamiento
        miPerro.MostrarDatos();
        miPerro.HacerSonido();     // Polimorfismo (Salida: Max dice: ¡Guau!)
        
    }
}
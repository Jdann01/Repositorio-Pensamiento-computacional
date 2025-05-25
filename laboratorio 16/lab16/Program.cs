using System;

class Program
{
    static void Main(string[] args)
    {
        string opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("=== CÁLCULO DE VOLUMEN DE UN CILINDRO ===");

            // Solicitar datos al usuario
            Console.Write("Ingresa el radio del cilindro: ");
            double radio = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingresa la altura del cilindro: ");
            double altura = Convert.ToDouble(Console.ReadLine());

            // Crear objeto de la clase Cilindro
            Cilindro cilindro1 = new Cilindro(radio, altura);

            // Mostrar información del cilindro
            Console.WriteLine("----------------------------------");
            cilindro1.MostrarInfo();

            // Calcular y mostrar volumen
            double volumen = cilindro1.CalcularVolumen();
            Console.WriteLine($"Volumen del cilindro: {volumen:F2}");
            Console.WriteLine("----------------------------------");

            // Preguntar si desea repetir
            Console.Write("¿Deseas calcular otro cilindro? (s/n): ");
            opcion = Console.ReadLine().ToLower();

        } while (opcion == "s");

        Console.WriteLine("Gracias por usar el programa.");
    }
}

class Cilindro
{
    // Atributos privados
    private double Radio;
    private double Altura;

    // Constructor
    public Cilindro(double radio, double altura)
    {
        Radio = radio;
        Altura = altura;
    }

    // Método para mostrar la información del cilindro
    public void MostrarInfo()
    {
        Console.WriteLine($"Radio: {Radio}");
        Console.WriteLine($"Altura: {Altura}");
    }

    // Método para calcular el volumen del cilindro
    public double CalcularVolumen()
    {
        return Math.PI * Radio * Radio * Altura;
    }
}







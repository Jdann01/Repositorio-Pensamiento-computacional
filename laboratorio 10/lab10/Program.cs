Random generador = new Random();
        int aleatorio = generador.Next(0, 51);
        int intento;
        bool adivinado = false;

        Console.WriteLine("Adivina el número (entre 0 y 50):");

        while (!adivinado)
        {
            Console.Write("Ingresa tu número: ");
            if (int.TryParse(Console.ReadLine(), out intento))
            {
                if (intento == aleatorio)
                {
                    Console.WriteLine("¡Felicidades! Has adivinado el número.");
                    adivinado = true;
                }
                else if (intento < aleatorio)
                {
                    Console.WriteLine("El número es mayor. Intenta de nuevo.");
                }
                else
                {
                    Console.WriteLine("El número es menor. Intenta de nuevo.");
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
            }
        }
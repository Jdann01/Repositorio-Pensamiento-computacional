// solicitar edad valida 
        int edad;

        do
        {
            Console.Write("Ingrese su edad (entre 1 y 100): ");
            if (int.TryParse(Console.ReadLine(), out edad))
            {
                if (edad < 1 || edad > 100)
                {
                    Console.WriteLine("Edad fuera de rango. Inténtelo de nuevo.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        } while (edad < 1 || edad > 100);

        Console.WriteLine($"Edad válida ingresada: {edad} años.");

    //solicitar numero de 0 para tabla de multiplicar

    int numero = 0;

        // Solicitar al usuario un número mayor a 0
        do
        {
            Console.Write("Ingrese un número entero mayor a 0: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out numero))
            {
                if (numero <= 0)
                {
                    Console.WriteLine("El número debe ser mayor a 0. Inténtelo de nuevo.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
      
            }

        } while (numero <= 0);

        // Generar y mostrar la tabla de multiplicar
        Console.WriteLine($"\nTabla de multiplicar del {numero}:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{numero} x {i} = {numero * i}");
        }
Console.Write("Ingrese una hora del día (formato 24 horas): ");
        int hora;

        if (int.TryParse(Console.ReadLine(), out hora))
        {
            if (hora >= 0 && hora <= 11)
            {
                Console.WriteLine("Buenos días");
            }
            else if (hora >= 12 && hora <= 18)
            {
                Console.WriteLine("Buenas tardes");
            }
            else if (hora >= 19 && hora <= 23)
            {
                Console.WriteLine("Buenas noches");
            }
            else
            {
                Console.WriteLine("Hora no válida. Introduzca una hora entre 0 y 23.");
            }
        }
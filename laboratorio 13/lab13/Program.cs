int opcion = 0;
     while (opcion!=4)
    {
        Console.WriteLine("------------------------------------------------------------------");
        Console.WriteLine("Bienvenido! Escoga una opcion: ");
        Console.WriteLine("");
        Console.WriteLine("Menú \n 1. Conversion Celsius a Fahrenheit \n 2. Conversion Fahrenheit a Celcius \n 3. Informacion del programador \n 4. Salir \n Ingrese su opcion");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine("------------------------------------------------------------------");
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese grados en celsius:");
                    double numero = double.Parse(Console.ReadLine());
                    double conversion1 = conversionCelciusFahrenheit(numero);
                    Console.WriteLine($"{numero} celsius a farenheit es: {conversion1}");
                    Console.WriteLine("------------------------------------------------------------------");
                    break;
                
                case 2:
                    Console.WriteLine("Ingrese grados en farenheit: ");
                    double numero2 = double.Parse(Console.ReadLine());
                    double conversion2 = conversionFahrenheitCelcius(numero2);
                    Console.WriteLine($"{numero2} farenheit a celsius es: {conversion2}");                    
                    Console.WriteLine("------------------------------------------------------------------");
                    break;
                
                case 3:
                    infoProgramador();
                    Console.WriteLine("------------------------------------------------------------------");
                    break;

                case 4:
                    Console.WriteLine("Gracias por utilizar nuestro programa");
                    Console.WriteLine("------------------------------------------------------------------");
                    break;

                default:
                    Console.WriteLine("Error, ingrese una opción del 1 al 4");
                    Console.WriteLine("------------------------------------------------------------------");
                    break;    
            }

    }
        
    double conversionCelciusFahrenheit(double num)
    {
        double conversionFarenheit = (( 1.8 )*(num))+32;
        return conversionFarenheit;
    }

    double conversionFahrenheitCelcius(double num)
    {
        double conversionCelcius = (num-32)/( 1.8 );
        return conversionCelcius;
    }

    void infoProgramador()
    {
        Console.WriteLine("Información del programador");
        Console.WriteLine("Nombre: Ian Martínez");
        Console.WriteLine("Universidad: Rafael Landívar");
        Console.WriteLine("Facultad: Ingenieria");
        Console.WriteLine("Carrera: Ingenieria en informática y sistemas");
        Console.WriteLine("Carné: 1115725");
        Console.WriteLine("Clase: Pensamiento computacional (Laboratorio)");
        Console.WriteLine("Seccion: 18");
    }
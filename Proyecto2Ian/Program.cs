using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Data;
using System.Numerics;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int opcion = 0;

        accionesParqueo acciones = new accionesParqueo();
        acciones.datosMatriz();

        while (opcion != 5)
        {

            //Menu
            Console.WriteLine("---------------------PARQUEOS PROYECTO 2----------------------");
            Console.WriteLine("Instrucciones del programa: \n 1. Ingresar vehículo \n 2.Buscar vehículo \n 3. Ingresar lote \n 4. Retirar vehículo \n 5. Salir\n Ingrese su opción: ");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            switch (opcion)
            {
                //Distintos casos segun la opcion elegida, se llamara a alguna clase
                case 1:
                    acciones.ingresarVehiculo();
                    break;
                case 2:
                    acciones.encontrarVehiculo();
                    break;
                case 3:
                    acciones.ingresarLote();
                    break;
                case 4:
                    acciones.retirarVehiculo();
                    break;
                case 5:
                    Console.WriteLine("Gracias por usar el sistema");
                    break;
                default:
                    Console.WriteLine("Error debe ingresar opciones del 1 al 5");
                    continue;
            }
        }
    }

}

class accionesParqueo
{
    //Varaibles globales publicas para acceder a ellas en cualquier momento en el codigo
    public int parqueoFilas;
    public int parqueoColumnas;
    public int parqueoHabilitados;
    public int parqueoMotos;
    public int parqueoSUV;
    public int parqueoSedan;
    public int parqueoDeshabilitado;
    public int totalParqueo;
    public string codigoIngresado;

    //Matriz
    public parqueo[,] matrizParqueo;

    //Numero aleatorio
    Random rnd = new Random();


    public accionesParqueo()
    {
        codigoIngresado = "";
    }

    public void datosMatriz()
    {
        //Solicitud de datos para la matriz
        Console.Write("Ingrese la cantidad de pisos para el parqueo: ");
        parqueoFilas = int.Parse(Console.ReadLine());

        Console.Write("Ingrese la cantidad de estacionamientos por piso: ");
        parqueoColumnas = int.Parse(Console.ReadLine());

        Console.Write("Ingrese la cantidad de parqueos habilitados al público: ");
        parqueoHabilitados = int.Parse(Console.ReadLine());

        Console.Write("Ingrese la cantidad de parqueos para motos: ");
        parqueoMotos = int.Parse(Console.ReadLine());

        Console.Write("Ingrese la cantidad de parqueos para SUV: ");
        parqueoSUV = int.Parse(Console.ReadLine());

        //Calculo de parqueo para vehiculos tipo sedan
        parqueoSedan = parqueoHabilitados - (parqueoMotos + parqueoSUV);

        //calculo total de parqueos y deshabilitados
        totalParqueo = parqueoFilas * parqueoColumnas;
        parqueoDeshabilitado = totalParqueo - parqueoHabilitados;

        //Creacion de matriz
        matrizParqueo = new parqueo[parqueoFilas, parqueoColumnas];

        //codigo parqueos
        InicializarParqueos();
    }

    private void InicializarParqueos()
    {
        //Creacion de codigos, clasificacion de parqueos por tipo de vehiculo
        string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int motosRestantes = parqueoMotos;
        int suvRestantes = parqueoSUV;
        int sedanRestantes = parqueoSedan;
        int habilitadosAsignados = 0;

        for (int i = 0; i < parqueoFilas; i++)
        {
            char letra = letras[i];
            for (int j = 0; j < parqueoColumnas; j++)
            {
                string codigo = letra.ToString() + (j+1).ToString();//se coloca j+1 para empezar por un codigo A1

                if (habilitadosAsignados < parqueoHabilitados)
                {
                    // Asignacion de disponibilidad
                    string tipo="";

                    if (motosRestantes > 0)
                    {
                        tipo = "moto";
                        motosRestantes--;
                    }
                    else if (suvRestantes > 0)
                    {
                        tipo = "suv";
                        suvRestantes--;
                    }
                    else if (sedanRestantes > 0)
                    {
                        tipo = "sedan";
                        sedanRestantes--;
                    }
                    
                    matrizParqueo[i, j] = new parqueo(codigo, tipo);
                    habilitadosAsignados++;
                }
                else
                {
                    // Estacionamiento deshabilitado
                    matrizParqueo[i, j] = null; 
                }
            }
        }
    }

    public void MostrarMapa(string tipoVehiculoUsuario)
    {
        //Mapa del estacionamiento
        Console.WriteLine("\nMapa del estacionamiento:");

        for (int i = 0; i < parqueoFilas; i++)
        {
            for (int j = 0; j < parqueoColumnas; j++)
            {
                parqueo espacio = matrizParqueo[i, j];

                if (espacio == null)
                {
                    Console.Write("X\t"); // parqueo deshabilitado
                }
                else if (espacio.disponibilidad)
                {
                    Console.Write("X\t"); // parqueo ocupado
                }
                else if (!string.IsNullOrWhiteSpace(codigoIngresado) &&
                        espacio.codigoParqueo.Equals(codigoIngresado.Trim(), StringComparison.OrdinalIgnoreCase)) // condicion compara los datos ingresados con datos anteriores
                {
                    Console.Write("X\t"); // se eligió este parqueo
                }
                else if (espacio.tipoVehiculo != tipoVehiculoUsuario)
                {
                    Console.Write("X\t"); // tipo incorrecto
                }
                else
                {
                    Console.Write(espacio.codigoParqueo + "\t"); // disponible y del tipo correcto
                }
            }
            Console.WriteLine();
        }
    }


    public void ingresarVehiculo()
    {
        //Solicitud datos del vehiculo
        Console.WriteLine("\n--- Ingreso de vehículo ---");

        Console.Write("Ingrese la marca del vehículo: ");
        string marca = Console.ReadLine();

        Console.Write("Ingrese el color del vehículo: ");
        string color = Console.ReadLine();

        string placa;
        while (true)
        {
            Console.Write("Ingrese la placa del vehículo (ej. 123ABC): ");
            placa = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(placa))//verificacion placa
                break;
            Console.WriteLine("La placa no puede estar vacía.");
        }

        string tipo;
        while (true)
        {
            Console.Write("Ingrese el tipo de vehículo (moto, suv, sedan): ");//opciones tipo vehiculo
            tipo = Console.ReadLine().ToLower();
            if (tipo == "moto" || tipo == "suv" || tipo == "sedan")
                break;
            Console.WriteLine("Tipo inválido. Debe ser moto, SUV o sedan.");
        }

        int horaEntrada;
        while (true)
        {
            Console.Write("Ingrese la hora de entrada (6 a 20): ");
            //El TryParse hace referencia a lo que se ingreso y la variable horaEntrada es quien esta almacenando la informacion 
            if (int.TryParse(Console.ReadLine(), out horaEntrada) && horaEntrada >= 6 && horaEntrada <= 20)// verifica hora de entrada (rango 6-20)
                break;
            Console.WriteLine("Hora inválida, ingrese entre 6 y 20.");
        }

        // Mostrar mapa con parqueos disponibles
        MostrarMapa(tipo);

        // Pedir código de parqueo y su validacion
        parqueo espacioElegido = null;
        while (true)
        {
            Console.Write("Ingrese el código del espacio donde desea estacionar: ");
            codigoIngresado = Console.ReadLine();


            // se busca el parqueo y se valida que este desocupado
            bool encontrado = false;
            for (int i = 0; i < parqueoFilas; i++)
            {
                for (int j = 0; j < parqueoColumnas; j++)
                {
                    parqueo espacio = matrizParqueo[i, j];
                    if (espacio != null && espacio.codigoParqueo.Equals(codigoIngresado, StringComparison.OrdinalIgnoreCase))//esto compara la informacion que se tiene con lo que se esta ingresando
                    {
                        encontrado = true;
                        if (espacio.tipoVehiculo != tipo)//aqui ve cuales son los parqueos distintos al tipo de vehiculo ingresado
                        {
                            Console.WriteLine("Ese espacio no es del tipo de vehículo indicado.");
                        }
                        else if (espacio.disponibilidad)//aqui ve si esta disponible
                        {
                            Console.WriteLine("Ese espacio ya está ocupado.");
                        }
                        else
                        {
                            espacioElegido = espacio;//luego de verificar ya asigna el parqueo ingresado
                        }
                        break;
                    }
                }
                if (encontrado) break;
            }

            //Sino se encuentra mostrara que es invalido y que ingrese otro 
            if (!encontrado)
            {
                Console.WriteLine("Código inválido, intente nuevamente.");
            }
            else if (espacioElegido != null)
            {
                break;
            }
        }

        // creacion del objeto vehiculo
        vehiculo nuevoVehiculo = new vehiculo(marca, color, placa, tipo, horaEntrada);

        // asignacion del parqueo y pasa a estar ocupado
        espacioElegido.vehiculoActual = nuevoVehiculo;
        espacioElegido.disponibilidad = true;

        Console.WriteLine($"Vehículo con placa {placa} ingresado en el espacio {espacioElegido.codigoParqueo}.");

        // Muestra el mapa actualizado
        MostrarMapa(tipo);
    }

    public void ingresarLote()
    {
        //variables con las distintas opciones que tendra el random
        string[] marcas = { "Honda", "Mazda", "Hyundai", "Toyota", "Suzuki" };
        string[] colores = { "Rojo", "Azul", "Negro", "Gris", "Blanco" };
        string[] tipos = { "moto", "sedan", "suv" };

        int cantidadVehiculos = rnd.Next(2, 7); // cantidad random de vehiculos

        Console.WriteLine($"\nIngresando lote de {cantidadVehiculos} vehículos");

        //se realiza una lista de los vehiculos random ingresados de manera ordenada y asi no se debera crear otra clase
        List<(string placa, string codigo)> vehiculosIngresados = new List<(string, string)>();

        for (int i = 0; i < cantidadVehiculos; i++)
        {
            //Se generan los random para cada vehiculo 
            string marca = marcas[rnd.Next(marcas.Length)];
            string color = colores[rnd.Next(colores.Length)];
            string tipo = tipos[rnd.Next(tipos.Length)];
            int horaEntrada = rnd.Next(6, 21); 
            string placa = GenerarPlaca();

            // Se busca el espacio del vehiculo entre los estacionamientos disponibles
            parqueo espacioLibre = null;
            for (int f = 0; f < parqueoFilas && espacioLibre == null; f++)
            {
                for (int c = 0; c < parqueoColumnas; c++)
                {
                    parqueo espacio = matrizParqueo[f, c];
                    if (espacio != null && !espacio.disponibilidad && espacio.tipoVehiculo == tipo)//Se verifica parqueo disponible y se asigna el parqueo
                    {
                        espacioLibre = espacio;
                        break;
                    }
                }
            }

            if (espacioLibre == null)
            {
                Console.WriteLine($"No hay espacio disponible para vehículo tipo {tipo} con placa {placa}.");//Esto en el caso no haya parqueo
                continue;
            }

            //se manda la informacion a la clase
            vehiculo v = new vehiculo(marca, color, placa, tipo, horaEntrada);
            espacioLibre.vehiculoActual = v;
            espacioLibre.disponibilidad = true;
            vehiculosIngresados.Add((placa, espacioLibre.codigoParqueo));
        }

        // Se muestra un listado de los vehiculos
        Console.WriteLine("\nVehículos ingresados:");
        foreach (var item in vehiculosIngresados)
        {
            Console.WriteLine($"Placa: {item.placa} - Estacionamiento: {item.codigo}");
        }

        // se muestra el mapa completo
        MostrarMapaLote();
    }

    private string GenerarPlaca()
    {
        // se genera una placa aleatoria con 3 numeros y 3 letras
        string numeros = rnd.Next(100, 1000).ToString();
        const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char[] letrasPlaca = new char[3];
        for (int i = 0; i < 3; i++)
            letrasPlaca[i] = letras[rnd.Next(letras.Length)];
        return numeros + new string(letrasPlaca); //concatenacion
    }

    private void MostrarMapaLote()
    {
        //se muestra el mapa 
        Console.WriteLine("\nMapa del estacionamiento completo:");

        for (int i = 0; i < parqueoFilas; i++)
        {
            for (int j = 0; j < parqueoColumnas; j++)
            {
                parqueo espacio = matrizParqueo[i, j];

                if (espacio == null)
                {
                    Console.Write("X\t"); // deshabilitado
                }
                else if (espacio.disponibilidad)
                {
                    Console.Write("X\t"); // ocupado
                }
                else
                {
                    Console.Write(espacio.codigoParqueo + "\t");
                }
            }
            Console.WriteLine();
        }
    }


    public void encontrarVehiculo()
    {
        //solicitud de numero de placa para buscar en donde esta ubicado el vehiculo y se muestran los datos del vehiculo al ser encontrado
        Console.Write("\nIngrese la placa del vehículo a buscar: ");
        string placaBuscada = Console.ReadLine().ToUpper();

        if (string.IsNullOrWhiteSpace(placaBuscada))
        {
            Console.WriteLine("Placa no puede estar vacía.");
            return;
        }

        bool encontrado = false;

        for (int i = 0; i < parqueoFilas && !encontrado; i++)
        {
            for (int j = 0; j < parqueoColumnas && !encontrado; j++)
            {
                parqueo espacio = matrizParqueo[i, j];
                if (espacio != null && espacio.disponibilidad && espacio.vehiculoActual != null)
                {
                    if (espacio.vehiculoActual.placaVehiculo.ToUpper() == placaBuscada)
                    {
                        Console.WriteLine($"\nVehículo encontrado en el espacio {espacio.codigoParqueo}:");
                        Console.WriteLine($"Marca: {espacio.vehiculoActual.marcaVehiculo}");
                        Console.WriteLine($"Color: {espacio.vehiculoActual.colorVehiculo}");
                        Console.WriteLine($"Tipo: {espacio.vehiculoActual.tipoVehiculo}");
                        Console.WriteLine($"Hora de entrada: {espacio.vehiculoActual.horaEntrada}");
                        encontrado = true;
                    }
                }
            }
        }

        if (!encontrado)
            Console.WriteLine("Vehículo no encontrado.");
    }

    public void retirarVehiculo()
    {
        //Se ingresa el codigo en donde esta el vehiculo para poder calcular su tiempo en el parqueo y el monto a cobrar
        Console.Write("\nIngrese el código del estacionamiento para retirar el vehículo: ");
        string codigo = Console.ReadLine().ToUpper();

        parqueo espacio = null;
        for (int i = 0; i < parqueoFilas; i++)
        {
            for (int j = 0; j < parqueoColumnas; j++)
            {
                if (matrizParqueo[i, j] != null && matrizParqueo[i, j].codigoParqueo == codigo)
                {
                    espacio = matrizParqueo[i, j];
                    break;
                }
            }
            if (espacio != null) break;
        }

        if (espacio == null || !espacio.disponibilidad || espacio.vehiculoActual == null)
        {
            Console.WriteLine("Código inválido o espacio desocupado.");
            return;
        }

        int horaEntrada = espacio.vehiculoActual.horaEntrada;
        int maxHoras = 24 - horaEntrada;
        int horasEstadia = (maxHoras > 0) ? rnd.Next(0, maxHoras + 1) : 0;

        Console.WriteLine($"Tiempo de estadía estimado: {horasEstadia} horas");

        // Tarifas de precios parqueo
        int tarifa = 0;
        if (horasEstadia <= 1) tarifa = 0;
        else if (horasEstadia >= 2 && horasEstadia <= 4) tarifa = 15;
        else if (horasEstadia >= 5 && horasEstadia <= 7) tarifa = 45;
        else if (horasEstadia >= 8 && horasEstadia <= 12) tarifa = 60;
        else if (horasEstadia > 12) tarifa = 150;

        Console.WriteLine($"Monto a pagar: Q{tarifa}");

        if (tarifa == 0)
        {
            Console.WriteLine("Cortesía por menos de una hora.");
        }

        // Metodos de pago
        string metodoPago = "";
        while (true)
        {
            Console.Write("Seleccione método de pago (tarjeta, efectivo, sticker): ");
            metodoPago = Console.ReadLine().ToLower();

            if (metodoPago == "tarjeta" || metodoPago == "efectivo" || metodoPago == "sticker")
                break;

            Console.WriteLine("Método inválido.");
        }

        //Si el metodo es en efectivo, se verifica si hay que dar vuelto
        if (metodoPago == "efectivo" && tarifa > 0)
        {
            int montoIngresado;
            while (true)
            {
                Console.Write("Ingrese el monto en efectivo: Q");
                if (int.TryParse(Console.ReadLine(), out montoIngresado) && montoIngresado >= tarifa)
                {
                    int vuelto = montoIngresado - tarifa;
                    if (vuelto > 0)
                    {
                        Console.WriteLine($"Vuelto a entregar: Q{vuelto}");
                        CalcularVuelto(vuelto);
                    }
                    break;
                }
                Console.WriteLine("Monto insuficiente o inválido.");
            }
        }
        else if (tarifa > 0)
        {
            Console.WriteLine($"Pago de Q{tarifa} recibido por {metodoPago}.");
        }

        // Se hace la confirmacion para habilitar el parqueo
        espacio.vehiculoActual = null;
        espacio.disponibilidad = false;

        Console.WriteLine("Salida confirmada. Espacio liberado.");

        // nuestra el mapa completo
        MostrarMapaLote();
    }

    private void CalcularVuelto(int vuelto)
    {
        //se calcula el vuelto del pago de efectivo, dice que billetes se tiene que dar y cuantos se deben dar
        int[] billetes = { 100, 50, 20, 10, 5 };
        Console.WriteLine("Desglose del vuelto:");
        foreach (int b in billetes)
        {
            int cantidad = vuelto / b;
            if (cantidad > 0)
            {
                Console.WriteLine($"Q{b}: {cantidad} billete(s)");
                vuelto %= b;
            }
        }
        if (vuelto > 0)
        {
            Console.WriteLine($"Queda un resto de Q{vuelto} no entregado (menos de Q5).");
        }
    }
}

class parqueo
{
    //clase utilizada para el parqueo porque se tendra varias veces un parqueo con caracteristicas similares
    public string codigoParqueo;
    public string tipoVehiculo;
    public bool disponibilidad;
    public vehiculo vehiculoActual;

    public parqueo(string codigoParqueo, string tipoVehiculo)
    {
        this.codigoParqueo = codigoParqueo;
        this.tipoVehiculo = tipoVehiculo;
        disponibilidad = false; 
        vehiculoActual = null;
    }
}

class vehiculo
{
    public string marcaVehiculo;
    public string colorVehiculo;
    public string placaVehiculo;
    public string tipoVehiculo;
    public int horaEntrada;

    //clase utilizada para el vehiculo porque se tendra varias veces un vehiculo con caracteristicas similares
    public vehiculo(string marcaVehiculo, string colorVehiculo, string placaVehiculo, string tipoVehiculo, int horaEntrada)
    {
        this.marcaVehiculo = marcaVehiculo;
        this.colorVehiculo = colorVehiculo;
        this.placaVehiculo = placaVehiculo;
        this.tipoVehiculo = tipoVehiculo;
        this.horaEntrada = horaEntrada;
    }
}
Console.Write("Bienvenido,Ingrese su nombre completo: ");
string nombre = Console.ReadLine();

Console.Write("Ingrese su altura en metros: ");
float altura = float.Parse(Console.ReadLine());

Console.Write("Ingrese su edad: ");
int edad = int.Parse(Console.ReadLine());

Console.Write("Ingrese la inicial de su mascota: ");
char inicial = char.Parse(Console.ReadLine());
       
Console.WriteLine("Impresion de datos:");
Console.WriteLine(nombre);
Console.WriteLine(altura);
Console.WriteLine(edad);
Console.WriteLine(inicial);

Console.WriteLine("Listado estudiantes y sus notas");

string[] estudiantes = { "Juan", "Pedro", "Luisa", "Adriana", "Sofia" };
int[] notas = { 88, 75, 96, 77, 59 };
int suma = 0;

Console.WriteLine("------------------------------------------------------------------");
for (int i = 0; i < estudiantes.Length; i++)
{
    Console.WriteLine($"{estudiantes[i]} - {notas[i]}");
    suma + = notas[i];
}
    double promedio = (double)suma / estudiantes.Length;
    Console.WriteLine();
    Console.WriteLine("El promedio es: " + promedio);
    Console.WriteLine("------------------------------------------------------------------");


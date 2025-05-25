Console.Write("Ingrese un texto:");
        string input = Console.ReadLine().Trim();
        int conteopalabra = 0;
        bool enPalabra = false;

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsWhiteSpace(input[i]))
            {
                enPalabra = false;
            }
            else if (!enPalabra)
            {
                enPalabra = true;
                conteopalabra++;
            }
        }

        // Capitalizar la primera letra de cada palabra
        char[] caracteres = input.ToLower().ToCharArray();
        bool nuevaPalabra = true;

        for (int i = 0; i < caracteres.Length; i++)
        {
            if (char.IsWhiteSpace(caracteres[i]))
            {
                nuevaPalabra = true;
            }
            else if (nuevaPalabra)
            {
                caracteres[i] = char.ToUpper(caracteres[i]);
                nuevaPalabra = false;
            }
        }

        string capitalizedText = new string(caracteres);

        Console.WriteLine($"Cantidad de palabras: {conteopalabra}");
        Console.WriteLine($"Texto modificado: {capitalizedText}");
        
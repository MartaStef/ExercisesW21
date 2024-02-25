do
{
    Console.WriteLine("Podaj liczbę całkowitą lub wpisz 'q' aby wyjść: ");
    var input = Console.ReadLine();

    if (input.ToLower() == "q" )
    {
        Console.WriteLine("Koniec programu.");
        break;
    }

    try
    {
        int number = int.Parse(input);
        char[] lettersAsNumber = input.ToArray();
        Console.WriteLine("Wynik dla liczby: " + input);

        for (char digit = '0'; digit <= '9'; digit++)
        {
            int count = 0;
            foreach (char letterAsNumber in lettersAsNumber)
            {
                if (letterAsNumber == digit)
                { count++; }
            }
            Console.WriteLine($"{digit} => {count}");
        }
        break;
    }
    catch (FormatException)
    {
        Console.WriteLine("Podany ciąg nie jest liczbą całkowitą. Spróbuj ponownie lub wpisz 'q' aby wyjść");
    }
}while(true);
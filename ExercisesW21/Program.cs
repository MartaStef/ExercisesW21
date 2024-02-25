
Console.WriteLine("Podaj liczbę całkowitą: ");
var numberAsString = Console.ReadLine();

try
{
    int number = int.Parse(numberAsString);
    char[] lettersAsNumber = numberAsString.ToArray();
    Console.WriteLine("Wynik dla liczby: " + numberAsString);

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
}
catch
{
    Console.WriteLine("Podany ciąg nie jest liczbą całkowitą");
}
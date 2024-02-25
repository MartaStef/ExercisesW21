
Console.WriteLine("Podaj liczbę: ");
var numberAsString = Console.ReadLine();
char[] lettersAsNumber = numberAsString.ToArray();
Console.WriteLine("Wynik dla liczby: " + numberAsString);

List<char> letters = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

foreach (char digit in letters)
{
    int count = 0;
    foreach (char letterAsNumber in lettersAsNumber)
    {
        if (letterAsNumber == digit)
        { count++; }
    }
    Console.WriteLine($"{digit} => {count}");
}

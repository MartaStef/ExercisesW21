﻿bool isWomen;

Console.WriteLine("Podaj imię:");
var name = Console.ReadLine();

Console.WriteLine("Podaj wiek");
var ageAsString = Console.ReadLine();
int age = int.Parse(ageAsString);

Console.WriteLine("Podaj płeć: m - mężczyzna, k - kobieta");
var sexAsString = Console.ReadLine();
if (sexAsString == "k") { isWomen = true; }
else { isWomen = false; }

if (isWomen && age < 30)
{
    Console.WriteLine("Kobieta poniżej 30 lat");
}
else if (name == "Ewa" && age == 30)
{
    Console.WriteLine("Ewa lat 30");
}
else if (!isWomen && age < 18)
{
    Console.WriteLine("Niepełnoletni mężczyzna");
}
else
{
   Console.WriteLine("Osoba poza zakresem parametrów");
}
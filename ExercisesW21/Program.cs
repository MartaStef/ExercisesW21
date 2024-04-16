using ExercisesW21;

Console.WriteLine("Witaj w programie 'SZCZUR' do oceny pracowników");
Console.WriteLine();
Console.WriteLine("Należy wpisać oceny od 0 do 100 lub od a do e.");
Console.WriteLine("Słowo 'next' kończy dodawanie ocen dla danego pracownika.");
Console.WriteLine("na koniec pojawią się statystyki najlepszego pracownika");
Console.WriteLine();

Employee employee1 = new Employee("Rutger","Hauer", 80, 'm');
Employee employee2 = new Employee("Arnold", "Schwarz", 77, 'm');
Employee employee3 = new Employee("Julia", "Roberts", 57, 'f');
Employee employee4 = new Employee("Johnny", "Depp", 60, 'm');

List<Employee> employees = new List<Employee>()
{ employee1, employee2, employee3, employee4 };

foreach (var employee in employees)
{
     while(true)
     {
        Console.WriteLine($"Podaj ocenę pracownika: {employee.Name}");
        var input = Console.ReadLine();
        if (input == "next")
        { break; }        
        employee.AddGrade(input);
     } 
}

float maxAverage = 0;
List<Employee> bestEmployees = new List<Employee>();

foreach (var employee in employees)
{
    var statistics = employee.GetStatistics();
    if (statistics.Average > maxAverage)
    {
        maxAverage = statistics.Average; 
        bestEmployees.Clear();
        bestEmployees.Add(employee);
    }    
    else if(statistics.Average == maxAverage)
    {
        bestEmployees.Add(employee);
    }
}

string text = " ";

foreach (var bestEmployee in bestEmployees)
{
    if (bestEmployee.Sex == 'm') { text = ", uzyskał wynik "; }
    if (bestEmployee.Sex == 'f') { text = ", uzyskała wynik "; }

    var bestStatistics = bestEmployee.GetStatistics();

    Console.WriteLine();
    Console.WriteLine($"Najlepszy pracownik:{bestEmployee.Name} {bestEmployee.Surname}, lat {bestEmployee.Age + text}");    
    Console.WriteLine($"Max:{bestStatistics.Max}");
    Console.WriteLine($"Min:{bestStatistics.Min}");
    Console.WriteLine($"Średnia liczbowa:{bestStatistics.Average:N2}");
    Console.WriteLine($"Średnia literowa:{bestStatistics.AverageLetter}");
}
using ExercisesW21;

Console.WriteLine("Witaj w programie 'SZCZUR' do oceny pracowników i kierowników");
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("Aby dodać pracownika należy wpisać literę p, a następnie oceny od 0 do 100 lub od a do e.");
Console.WriteLine("Aby dodać kierownika należy wpisać literę k, a następnie oceny od 1 do 6 (z +/-) lub od a do e.");
Console.WriteLine("Słowo 'next' kończy dodawanie ocen dla danego pracownika lub kierownika");
Console.WriteLine("Na koniec pojawią się statystyki najlepszego pracownika lub kierownika");
Console.WriteLine();

List<Employee> employees = new List<Employee>();

List<Supervisor> supervisors = new List<Supervisor>();

while(true)
{
    Console.WriteLine("Wpisz p aby dodać pracownika, k aby dodać kierownika, q aby zakończyc");
    var type = Console.ReadLine();
    if (type == "p" || type == "P")
    {
        Console.WriteLine("Podaj imię:");
        string name = Console.ReadLine();
        Console.WriteLine("Podaj nazwisko:");
        string surname = Console.ReadLine();
        Console.WriteLine("Podaj wiek:");
        int age = int.Parse(Console.ReadLine());
        try
        {
            Console.WriteLine("Podaj płeć (m/f)");
            char sex = char.Parse(Console.ReadLine());
            Employee employee = new Employee(name, surname, age, sex);
            employees.Add(employee);
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
            continue;
        }
    }
    else if(type == "k" || type == "K")
    { 
        Console.WriteLine("Podaj imię:");
        string name = Console.ReadLine();
        Console.WriteLine("Podaj nazwisko:");
        string surname = Console.ReadLine();
        Console.WriteLine("Podaj wiek:");
        int age = int.Parse(Console.ReadLine());
        try
        {
            Console.WriteLine("Podaj płeć (m/f)");
            char sex = char.Parse(Console.ReadLine());
            Supervisor supervisor = new Supervisor(name, surname, age, sex);
            supervisors.Add(supervisor);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }
    }    
    else if (type == "q")
    { break; }
    else
    {
        Console.WriteLine("Niepoprawny typ. Spróbuj ponownie");
        continue;
    }
}

foreach (var employee in employees)
{
    while (true)
    {        
        Console.WriteLine($"Podaj ocenę pracownika: {employee.Name}");
        var input = Console.ReadLine();
        if (input == "next")
        { break; }
        try
        {
            employee.AddGrade(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
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
    else if (statistics.Average == maxAverage)
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

foreach (var supervisor in supervisors)
{
    while (true)
    {
        Console.WriteLine($"Podaj ocenę kierownika: {supervisor.Name}");
        var input = Console.ReadLine();
        if (input == "next")
        { break; }
        try
        {
            supervisor.AddGrade(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

maxAverage = 0;

List<Supervisor> bestSupervisors = new List<Supervisor>();

foreach (var supervisor in supervisors)
{
    var statistics = supervisor.GetStatistics();
    if (statistics.Average > maxAverage)
    {
        maxAverage = statistics.Average;
        bestSupervisors.Clear();
        bestSupervisors.Add(supervisor);
    }
    else if (statistics.Average == maxAverage)
    {
        bestSupervisors.Add(supervisor);
    }
}

foreach (var bestSupervisor in bestSupervisors)
{
    if (bestSupervisor.Sex == 'm') { text = ", uzyskał wynik "; }
    if (bestSupervisor.Sex == 'f') { text = ", uzyskała wynik "; }

    var bestStatistics = bestSupervisor.GetStatistics();

    Console.WriteLine();
    Console.WriteLine($"Najlepszy kierownik:{bestSupervisor.Name} {bestSupervisor.Surname}, lat {bestSupervisor.Age + text}");
    Console.WriteLine($"Max:{bestStatistics.Max}");
    Console.WriteLine($"Min:{bestStatistics.Min}");
    Console.WriteLine($"Średnia liczbowa:{bestStatistics.Average:N2}");
    Console.WriteLine($"Średnia literowa:{bestStatistics.AverageLetter}");
}
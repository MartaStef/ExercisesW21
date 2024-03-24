using ExercisesW21;

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
        Console.WriteLine("Podaj ocenę pracownika:" + employee.Name);
        var input = Console.ReadLine();
        if (input == "next")
        { break; }
        var grade = float.Parse(input);
        employee.AddGrade(grade);
     } 
}

float maxAverage = 0;
Employee bestEmployee = null;
Statistics bestStatistics = null;

foreach (var employee in employees)
{
    var statistics = employee.GetStatistics();
    if (statistics.Average > maxAverage)
    {        
        maxAverage = statistics.Average;
        bestEmployee = employee;
        bestStatistics = statistics;
    }
}

string text = " ";

if (bestEmployee.Sex == 'm') { text = ", uzyskał wynik"; }
if (bestEmployee.Sex == 'f') { text = ", uzyskała wynik "; }

Console.WriteLine($"Najlepszy pracownik:{bestEmployee.Name} + {bestEmployee.Surname}, lat {bestEmployee.Age + text}");
Console.WriteLine($"Max:{bestStatistics.Max}");
Console.WriteLine($"Min:{bestStatistics.Min}");
Console.WriteLine($"Średnia:{bestStatistics.Average:N2}");
 

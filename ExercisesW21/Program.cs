using ExercisesW21;

Console.WriteLine("Witaj w programie 'SZCZUR' do oceny pracowników i kierowników");
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("Aby dodać pracownika sezonowego wpisz literę s, oceny od 0 do 100 lub od a do e.");
Console.WriteLine("Aby dodać pracownika stałego wpisz literę p, oceny od 0 do 100 lub od a do e.");
Console.WriteLine("Aby dodać kierownika należy wpisać literę k, oceny od 1 do 6 (z +/-) lub od a do e.");
Console.WriteLine("Słowo 'next' kończy dodawanie ocen dla danego pracownika lub kierownika");
Console.WriteLine("Na koniec pojawią się statystyki najlepszego pracownika lub kierownika");
Console.WriteLine();

List<Employee> employees = new List<Employee>();

List<EmployeeInFile> employeesInFile = new List<EmployeeInFile>();

List<Supervisor> supervisors = new List<Supervisor>();

 void AddEmployeeData<T>(List<T> employeesList) where T : EmployeeBase
{
    Console.WriteLine("Podaj imię:");
    string name = Console.ReadLine();
    Console.WriteLine("Podaj nazwisko:");
    string surname = Console.ReadLine();
    Console.WriteLine("Podaj wiek:");
    int age = int.Parse(Console.ReadLine());
    Console.WriteLine("Podaj dział:");
    string departmentString = (Console.ReadLine());
    Department department;
    Enum.TryParse(departmentString, out department);
    try
    {
        Console.WriteLine("Podaj płeć (m/f)");
        char sex = char.Parse(Console.ReadLine());
        if (employeesList is List<Employee>)
        {
            Employee employee = new Employee(name, surname, age, sex, department);
            employees.Add(employee);
        }
        else if (employeesList is List<EmployeeInFile>)
        {
            EmployeeInFile employeeInFile = new EmployeeInFile(name, surname, age, sex, department);
            employeesInFile.Add(employeeInFile);
        }
        else if (employeesList is List<Supervisor>)
        {
            Supervisor supervisor = new Supervisor(name, surname, age, sex, department);
            supervisors.Add(supervisor);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);        
    }
    
 } 

while(true)
{
    Console.WriteLine("Wpisz s lub p aby dodać pracownika, k aby dodać kierownika, q aby zakończyc");
    var type = Console.ReadLine();
    if (type == "s" || type == "S")
    {
        AddEmployeeData(employees);
    }
    else if(type == "p" || type == "P")
    {
        AddEmployeeData(employeesInFile);
    }
    else if(type == "k" || type == "K")
    {
        AddEmployeeData(supervisors);
    }    
    else if (type == "q")
    { break; }
    else
    {
        Console.WriteLine("Niepoprawny typ. Spróbuj ponownie");
        continue;
    }
}

void AddGradeToEmployee<T>(List<T> employeesList) where T : EmployeeBase
{
    foreach (var employee in employeesList)
    {
        while (true)
        {
            Console.WriteLine($"Podaj ocenę pracownika {employee.Name}");
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
}

static List<T> FindBestEmployees<T>(List<T> employeesList) where T : EmployeeBase
{
    float maxAverage = 0;
    List<T> bestEmployees = new List<T>();

    foreach (var employee in employeesList)
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
    return bestEmployees;
}

AddGradeToEmployee(employees);
AddGradeToEmployee(employeesInFile);
AddGradeToEmployee(supervisors);

var bestEmployees = FindBestEmployees(employees);
var bestEmployeesInFile = FindBestEmployees(employeesInFile);
var bestSupervisors = FindBestEmployees(supervisors);

string text = " ";

foreach (var bestEmployee in bestEmployees)
{
    if (bestEmployee.Sex == 'm') { text = ", uzyskał wynik "; }
    if (bestEmployee.Sex == 'f') { text = ", uzyskała wynik "; }

    var bestStatistics = bestEmployee.GetStatistics();

    Console.WriteLine();
    Console.WriteLine($"Najlepszy pracownik sezonowy" +
        $":{bestEmployee.Name} {bestEmployee.Surname}, lat {bestEmployee.Age + text}");
    Console.WriteLine($"Max:{bestStatistics.Max}");
    Console.WriteLine($"Min:{bestStatistics.Min}");
    Console.WriteLine($"Średnia liczbowa:{bestStatistics.Average:N2}");
    Console.WriteLine($"Średnia literowa:{bestStatistics.AverageLetter}");
}

foreach (var bestEmployeeInFile in bestEmployeesInFile)
{
    if (bestEmployeeInFile.Sex == 'm') { text = ", uzyskał wynik "; }
    if (bestEmployeeInFile.Sex == 'f') { text = ", uzyskała wynik "; }

    var bestStatistics = bestEmployeeInFile.GetStatistics();

    Console.WriteLine();
    Console.WriteLine($"Najlepszy pracownik:{bestEmployeeInFile.Name} {bestEmployeeInFile.Surname}, lat {bestEmployeeInFile.Age + text}");
    Console.WriteLine($"Max:{bestStatistics.Max}");
    Console.WriteLine($"Min:{bestStatistics.Min}");
    Console.WriteLine($"Średnia liczbowa:{bestStatistics.Average:N2}");
    Console.WriteLine($"Średnia literowa:{bestStatistics.AverageLetter}");
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
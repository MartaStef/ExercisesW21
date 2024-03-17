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
        var grade = int.Parse(input);
        employee.AddGrade(grade);
     } 
}

int maxResult = 0;

Employee bestEmployee = null;

foreach (var employee in employees)
{
    if (employee.Result > maxResult)
    {
        bestEmployee = employee;
        maxResult = employee.Result;
    }
}

string text = " ";

if (bestEmployee.Sex == 'm') { text = ", uzyskal wynik "; }
if (bestEmployee.Sex == 'f') { text = ", uzyskała wynik "; }

Console.WriteLine($"Najlepszy pracownik: " + bestEmployee.Name + " " + bestEmployee.Surname + ", lat " +
bestEmployee.Age + text + bestEmployee.Result + " punktow"); 
 

using ExercisesW21;

Employee employee1 = new Employee("Rutger","Hauer", 80, 'm');
Employee employee2 = new Employee("Arnold", "Schwarz", 77, 'm');
Employee employee3 = new Employee("Julia", "Roberts", 57, 'f');

employee1.AddGrade(5);
employee1.AddGrade(3);
employee1.AddGrade(4);

employee2.AddGrade(5);
employee2.AddGrade(8);
employee2.AddGrade(7);
employee2.AddGrade(9);

employee3.AddGrade(10);
employee3.AddGrade(11);

List<Employee> employees = new List<Employee>()
{ employee1, employee2, employee3 };

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
    


namespace ExercisesW21.Tests
{
    public class EmployeeTests
    {
        [Test]
        public void WhenGradesNumbresAreAdded_ReturnsCorrectResult()
        {            
            //Arange
            var employee = new Employee("Angelina", "Jolie", 57, 'f', Department.Marketing);
            employee.AddGrade(25);
            employee.AddGrade(79);
            employee.AddGrade(18);
            employee.AddGrade(33);

            //Act
            var statistics = employee.GetStatistics();

            //Assert
            Assert.AreEqual(18, statistics.Min);
            Assert.AreEqual(79, statistics.Max);
            Assert.AreEqual(38.75, (float)Math.Round(statistics.Average, 2));
            Assert.AreEqual('D', statistics.AverageLetter);
        }

        [Test]
        public void WhenGradesLettersAreAdded_ReturnsCorrectResult()
        {            
            //Arange
            var employee = new Employee("Angelina", "Jolie", 57, 'f', Department.Marketing);
            employee.AddGrade('A');
            employee.AddGrade('B');
            employee.AddGrade('C');
            employee.AddGrade('d');

            //Act
            var statistics = employee.GetStatistics();

            //Assert
            Assert.AreEqual(40, statistics.Min);
            Assert.AreEqual(100, statistics.Max);
            Assert.AreEqual(70f, (float)Math.Round(statistics.Average, 2));
            Assert.AreEqual('B', statistics.AverageLetter);
        }
    }
}

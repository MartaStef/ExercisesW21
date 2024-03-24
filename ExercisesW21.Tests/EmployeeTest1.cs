namespace ExercisesW21.Tests
{
    public class Tests
    {
        [Test]
        public void WhenGetStatisticsCalled_ShouldReturnCorrectMax()
        {
            // arrange
            var employee = new Employee("Angelina", "Jolie", 49, 'f');
            employee.AddGrade(5);
            employee.AddGrade(6);
            employee.AddGrade(9);

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(9, statistics.Max);
        }

        [Test]
        public void WhenGetStatisticsCalled_ShouldReturnCorrectMin()
        {
            // arrange
            var employee = new Employee("Angelina", "Jolie", 49, 'f');
            employee.AddGrade(5);
            employee.AddGrade(6);
            employee.AddGrade(9);

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(5, statistics.Min);
        }

        [Test]
        public void WhenGetStatisticsCalled_ShouldReturnCorrectAverage()
        {
            // arrange
            var employee = new Employee("Angelina", "Jolie", 49, 'f');
            employee.AddGrade(5);
            employee.AddGrade(6);
            employee.AddGrade(9);

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(Math.Round(6.67,2), Math.Round(statistics.Average,2));
        }
    }
}
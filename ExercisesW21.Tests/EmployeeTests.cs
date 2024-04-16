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
            employee.AddGrade(3);

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(6, statistics.Max);
        }

        [Test]
        public void WhenGetStatisticsCalled_ShouldReturnCorrectMin()
        {
            // arrange
            var employee = new Employee("Angelina", "Jolie", 49, 'f');
            employee.AddGrade(5);
            employee.AddGrade(6);
            employee.AddGrade(3);

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(3, statistics.Min);
        }

        [Test]
        public void WhenGetStatisticsCalled_ShouldReturnCorrectAverage()
        {
            // arrange
            var employee = new Employee("Angelina", "Jolie", 49, 'f');
            employee.AddGrade(5);
            employee.AddGrade(6);
            employee.AddGrade(3);

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(Math.Round(4.66, 2), Math.Round(statistics.Average, 2));
        }


        [Test]
        public void WhenGetStatisticsCalled_ShouldReturnCorrectAverageLetter()
        {
            // arrange
            var employee = new Employee("Angelina", "Jolie", 49, 'f');
            employee.AddGrade(50);
            employee.AddGrade(61);
            employee.AddGrade(23);
            employee.AddGrade('a');

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.That(statistics.AverageLetter, Is.EqualTo('C'));
        }
    }
}
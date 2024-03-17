namespace ExercisesW21.Tests
{
    public class Tests
    {
        [Test]
        public void WhenEmployeeCollectGrades_ShouldCorrectSum()
        {
            // arrange
            var employee = new Employee("Angelina", "Jolie", 49,'f');
            employee.AddGrade(5);
            employee.AddGrade(6);

            // act
            var result = employee.Result;

            // assert
            Assert.AreEqual(11,result);
        }
    }
}
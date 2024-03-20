namespace ExercisesW21.Tests
{
    public class TypeTests
    {
        [Test]
        public void Test_String()
        {
            // arrange
            string name1 = "Glut";
            string name2 = "Glut";

            // act

            // assert
            Assert.AreEqual(name1, name2);
        }

        [Test]
        public void Test_Int()
        {
            // arrange
            int number1 = 21;
            int number2 = 21;

            // act

            // assert
            Assert.AreEqual(number1, number2);            
        }

        [Test]
        public void Test_Reference()
        {
            // arrange
            var employee1 = GetEmployee("Olga");
            var employee2 = GetEmployee("Olga");

            // act

            // assert
            Assert.AreNotEqual(employee1, employee2);
            Assert.AreEqual(employee1.Name, employee2.Name);
        }

        private Employee GetEmployee(string name)
        {
            return new Employee (name);
        }
    }
}

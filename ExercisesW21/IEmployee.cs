using static ExercisesW21.EmployeeBase;

namespace ExercisesW21
{
    public interface IEmployee
    {
        public event GradeAddedDelegate GradeAdded;
        string Name { get; }
        string Surname { get; }
        int Age { get; }
        char Sex { get; }
        Department Department { get; }

        void AddGrade(float grade);
        void AddGrade(string grade);
        void AddGrade(char grade);
        Statistics GetStatistics();
    }
}

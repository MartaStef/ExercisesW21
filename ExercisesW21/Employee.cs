namespace ExercisesW21
{
    public class Employee
    {
        private List<float> grades = new List<float>();
        public Employee(string name)
        {
        this.Name = name;
        }
    
        public Employee(string name, string surname, int age, char sex)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Sex = sex;
        }
        public string Name { get; private set; }
        public string Surname { get;private set; }
        public int Age { get; private set;}
        public char sex;
        public char Sex 
        {
            get 
            { 
                return sex;
            }
            set 
            {
                if (value == 'm' || value == 'f')
                {
                    sex = value;
                }
                else
                {
                    throw new ArgumentException("invalid sex");
                }
            }
        }
                
        public void AddGrade(float grade) 
        { 
        this.grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Max = float.MinValue;
            statistics.Min = float.MaxValue;

            foreach (var grade in this.grades)
            {
                statistics.Average += grade;
                statistics.Max = Math.Max(statistics.Max, grade);
                statistics.Min = Math.Min(statistics.Min, grade);
            }
            statistics.Average /= this.grades.Count;
            return statistics;
        }
    }
}

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
                    throw new ArgumentException("Invalid sex");
                }
            }
        }
                
        public void AddGrade(float grade) 
        { 
            if (grade >=0 && grade <= 100)
            {
                this.grades.Add(grade);
            }           
            else 
            {
                Console.WriteLine("Invalid grade value");
            }
        }

        public void AddGrade(string grade)
        {
            if(float.TryParse(grade, out float result)) 
            { 
                this.grades.Add(result);
            }
            else 
            {
                Console.WriteLine("String is not float");
            }
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

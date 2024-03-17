namespace ExercisesW21
{
    public class Employee
    {
        private List<int> grades = new List<int>();
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

        public int Result
        { 
            get
            { 
                return this.grades.Sum(); 
            }
        }

        public void AddGrade(int grade) 
        { 
        this.grades.Add(grade);
        }
    }
}

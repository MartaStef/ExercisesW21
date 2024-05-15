namespace ExercisesW21
{
    public abstract class EmployeeBase : IEmployee
    {
        public EmployeeBase(string name, string surname, int age, char sex, Department depatment) 
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Sex = sex;
            this.Department = depatment;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }        
        
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
                    throw new Exception("Invalid sex");
                }
            }
        }
        public Department Department { get; set; }

        public abstract void AddGrade(float grade);

        public abstract void AddGrade(string grade);
       
        public abstract void AddGrade(char grade);

        public abstract Statistics GetStatistics();        
    }
}

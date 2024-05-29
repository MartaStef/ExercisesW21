namespace ExercisesW21
{
    public class Supervisor : EmployeeBase
    {
        private List<float> grades = new List<float>();

        public override event GradeAddedDelegate GradeAdded;
        public Supervisor(string name, string surname, int age, char sex, Department department)
            : base (name, surname, age, sex, department)
        {           
        }
        
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception($"{grade} is invalid grade value");
            }
        }

        public override void AddGrade(string grade)
        {
            if (grade.Length == 1)
            {
                char.TryParse(grade, out char charResult);
                this.AddGrade(charResult);
            }
            else if (grade.Length == 2 && char.IsDigit(grade[0]) && grade[0] >= '1' && grade[0] <= '6' && (grade[1] == '+' || grade[1] == '-'))
            {
                float mappedGrade = grade switch
                {
                    "6-" or "-6" => 95,
                    "5+" or "+5" => 85,
                    "5-" or "-5" => 75,
                    "4+" or "+4" => 65,
                    "4-" or "-4" => 55,
                    "3+" or "+3" => 45,
                    "3-" or "-3" => 35,
                    "2+" or "+2" => 25,
                    "2-" or "-2" => 15,
                    "1+" or "+1" => 5,
                    _ => float.TryParse(grade, out float result) ? result : 0,
                };
                if (mappedGrade >= 0) 
                {
                this.AddGrade(mappedGrade);
                }
            }
            else
            {
                throw new Exception("String is not float");
            }
        }

        public override void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'a':
                case 'A':
                case '6':
                    this.AddGrade(100);
                    break;
                case 'b':
                case 'B':
                case '5':
                    this.AddGrade(80);
                    break;
                case 'c':
                case 'C':
                case '4':
                    this.AddGrade(60);
                    break;
                case 'd':
                case 'D':
                case '3':
                    this.AddGrade(40);
                    break;
                case 'e':
                case 'E':
                case '2':
                    this.AddGrade(20);
                    break;
                case '1':
                    this.AddGrade(0);
                    break;
                default:
                    throw new Exception("Wrong Letter");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();           
            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }           
            return statistics;
        }
    }

}

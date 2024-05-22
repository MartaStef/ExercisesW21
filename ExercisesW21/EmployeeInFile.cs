namespace ExercisesW21
{
    public class EmployeeInFile : EmployeeBase
    {
        public override event GradeAddedDelegate GradeAdded;

        private string fileName;
        public EmployeeInFile(string name, string surname, int age, char sex, Department department)
            : base(name, surname, age, sex, department)
        {
            fileName = $"{name}_{surname}_grades.txt";
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                }
                if (GradeAdded!= null) 
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception($"{grade}is invalid grade value");
            }
        }

        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else if (grade.Length == 1)
            {
                char.TryParse(grade, out char charResult);
                this.AddGrade(charResult);
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
                    this.AddGrade(100);
                    break;
                case 'b':
                case 'B':
                    this.AddGrade(80);
                    break;
                case 'c':
                case 'C':
                    this.AddGrade(60);
                    break;
                case 'd':
                case 'D':
                    this.AddGrade(40);
                    break;
                case 'e':
                case 'E':
                    this.AddGrade(20);
                    break;
                default:
                    throw new Exception($"{grade}is wrong letter");
            }
        }

        public override Statistics GetStatistics()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
            return result;
        }
        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }

        private Statistics CountStatistics(List<float> grades)
        {
            var statistics = new Statistics();           
            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }           
            return statistics;
        }
    }
}

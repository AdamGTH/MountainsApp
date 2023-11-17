

namespace MyMountainApp
{
    public class MTrailsInMemory : MTrailsBase
    {
        public MTrailsInMemory(string name, string desc, string place, int lenght)
             : base(name, desc, place, lenght)
        {
            
        }
        public MTrailsInMemory()
          : base("NONE", "NONE", "NONE", 0)
        {

        }

        List<float> Grades = new List<float>();

        public override event GradeAddedDelegate GradeAdded;
        
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in this.Grades)
            {
                statistics.AddGrade(grade);
            }

            return statistics;
        }

        public override void DifficultyLevel(float grade)
        {
            if (grade >= 0 && grade <= 5)
            {
                this.Grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            else
                throw new Exception("Invalid data");
        }

        public override void DifficultyLevel(string grade)
        {
            if (float.TryParse(grade, out var points))
            {
                this.DifficultyLevel(points);
            }
            else
                throw new Exception("Value is not float");
        }

        public override void DifficultyLevel(double grade)
        {
            this.DifficultyLevel((float)grade); 
        }

        public override void DifficultyLevel(long grade)
        {
            this.DifficultyLevel((float)grade);
        }

    }
}



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

        List<float> grades = new List<float>();

        public override event GradeAddedDelegate GradeAdded;
        
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }

            return statistics;
        }

        public override void DifficultyLevel(float grade)
        {
            if (grade >= 0 && grade <= 5)
            {
                this.grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            else
                throw new Exception("Invalid data");
        }
        
    }
}



namespace MyMountainApp
{
    public abstract class MTrailsBase : IMTrails
    {
       public MTrailsBase(string name, string description, string place, int lenght  ) 
       {
            this.TrailName = name;
            this.TrailDescription = description;
            this.TrailPlace = place;
            this.LenghtOfTheTrail = lenght;
       }
        public string TrailName {  get; private set; }
        public string TrailDescription { get; private set; }
        public string TrailPlace { get; private set; }
        public int LenghtOfTheTrail { get; private set; }

        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public abstract event GradeAddedDelegate GradeAdded;
              
        public abstract Statistics GetStatistics();
        public abstract void DifficultyLevel(float grade);
        public void DifficultyLevel(string grade)
        {

            if (float.TryParse(grade, out var points))
            {
                this.DifficultyLevel(points);
            }
            else
                throw new Exception("Value is not float");
        }

        public void DifficultyLevel(double grade)
        {
            this.DifficultyLevel((float)grade);
        }

        public void DifficultyLevel(long grade)
        {
            this.DifficultyLevel((float)grade);
        }
                
    }
}

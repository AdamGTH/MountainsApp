

namespace MyMountainApp
{
    public abstract class MTrailsBase : IMTrails
    {
       public MTrailsBase(string name, string description, string place, int seaLevel, int lenght  ) 
       {
            this.TrailName = name;
            this.TrailDescription = description;
            this.TrailPlace = place;
            this.SeaLevel = seaLevel;
            this.LenghtOfTheTrail = lenght;
       }
        public string TrailName {  get; private set; }
        public string TrailDescription { get; private set; }
        public string TrailPlace { get; private set; }
        public int SeaLevel { get; private set; }
        public float LenghtOfTheTrail { get; private set; }

        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void DifficultyLevel(float grade);
        public abstract void DifficultyLevel(string grade);
        public abstract void DifficultyLevel(double grade);
        public abstract void DifficultyLevel(long grade);
        public abstract Statistics GetStatistics();
        
    }
}

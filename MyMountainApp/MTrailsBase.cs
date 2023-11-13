

namespace MyMountainApp
{
    public abstract class MTrailsBase : IMTrails
    {
       public MTrailsBase(string name, string desc, string place, int seaLevel, int lenght  ) 
       {
            this.TrailName = name;
            this.TrailDesc = desc;
            this.TrailPlace = place;
            this.HeightSeaLevel = seaLevel;
            this.LenghtOfTheTrail = lenght;
            
       }
        public string TrailName {  get; private set; }
        public string TrailDesc { get; private set; }
        public string TrailPlace { get; private set; }
        public int HeightSeaLevel { get; private set; }
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

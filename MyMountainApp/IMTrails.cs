

using static MyMountainApp.MTrailsBase;

namespace MyMountainApp
{
    public interface IMTrails
    {
        string TrailName { get; }
        string TrailDescription { get; }
        string TrailPlace { get; }
        int LenghtOfTheTrail { get; }

        event GradeAddedDelegate GradeAdded;
        
        void DifficultyLevel(float grade);
        void DifficultyLevel(string grade);
        void DifficultyLevel(double grade);
        void DifficultyLevel(long grade);
        Statistics GetStatistics();
    }
}

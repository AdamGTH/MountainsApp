

namespace MyMountainApp
{
    internal interface IMTrails
    {
        string TrailName { get; }
        string TrailDesc { get; }
        string TrailPlace { get; }
        int HeightSeaLevel { get; }
        float LenghtOfTheTrail { get; }

        void DifficultyLevel(float grade);
        void DifficultyLevel(string grade);
        void DifficultyLevel(double grade);
        void DifficultyLevel(long grade);
        Statistics GetStatistics();

        
    }
}

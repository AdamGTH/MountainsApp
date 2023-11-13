

namespace MyMountainApp
{
    public class Statistics
    {
        public Statistics()
        {
            this.Count = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
            this.Sum = 0;
        }
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Average { get { return this.Sum / this.Count; } private set { } }
        public int Count { get; private set; }
        public float Sum { get; private set; }
        public string AverageString
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average >= 4:
                        return "Very Hard";

                    case var average when average >= 3:
                        return "Hard";

                    case var average when average >= 2:
                        return "Moderate";

                    case var average when average >= 1:
                        return "Light";

                    case var average when average >= 0:
                        return "Very Light";

                    default:
                        return "None";

                }
            }
            private set { }
        }
        public void AddGrade(float grade)
        {
            this.Count++;
            this.Sum += grade;
            this.Max = Math.Max(this.Max, grade);
            this.Min = Math.Min(this.Min, grade);
        }
    }
}

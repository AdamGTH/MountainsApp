

using System.Diagnostics;
using System.Xml.Linq;

namespace MyMountainApp
{
    public class MTrailsInFile : MTrailsBase
    {
        public MTrailsInFile(string name, string desc, string place, int seaLevel, int lenght)
            : base(name, desc, place, seaLevel, lenght)
        {
            this.FileNameGrades = $"{name}.txt";
            this.FileNameDescription = $"{name}-Description" ;
        }
        public MTrailsInFile()
          : base("NONE", "NONE", "NONE", 0, 0)
        {
            this.FileNameGrades = $"NoName.txt";
            this.FileNameDescription = $"NoName-Description";
        }
        public override event GradeAddedDelegate GradeAdded;
        public string FileNameGrades;
        public string FileNameDescription;
        public override void DifficultyLevel(float grade)
        {
            using (var writer = File.AppendText($"{base.TrailName}.txt"))
            {
                writer.WriteLine(grade);
            }
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
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
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            List<float> grades = new List<float>();

            if (File.Exists($"{base.TrailName}.txt"))
            {
                using (var reader = File.OpenText($"{base.TrailName}.txt"))
                {
                    var lines = reader.ReadLine();
                    while (lines != null)
                    {
                        grades.Add(float.Parse(lines));
                        lines = reader.ReadLine();
                    }
                }
                foreach (var grade in grades)
                {
                    statistics.AddGrade(grade);
                }
            }
            return statistics;
        }

        public void SaveDescription()
        {
            using (var writer = File.AppendText($"{base.TrailName}-Description.txt"))
            {
                writer.WriteLine(base.TrailDescription);
            }
        }

        public string LoadDescription() 
        {
            string sumOfLine = "";
            if(File.Exists($"{base.TrailName}-Description.txt"))
            {
                using (var reader = File.OpenText($"{base.TrailName}-Description.txt"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        sumOfLine += line + "\n";
                        line = reader.ReadLine();
                    }
                }
            }
          
            return sumOfLine;
        }
    }
}

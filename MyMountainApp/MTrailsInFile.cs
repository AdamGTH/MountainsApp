

using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace MyMountainApp
{
    public class MTrailsInFile : MTrailsBase
    {
        public MTrailsInFile(string name, string desc, string place, int lenght)
            : base(name, desc, place, lenght)
        {
            this.FileName = $"{name}.txt";
            using (var writer = File.CreateText(this.FileName))
            {
                writer.WriteLine("Nazwa szlaku:");
                writer.WriteLine(name+"\n");
                writer.WriteLine("Miejsce:");
                writer.WriteLine(place + "\n");
                writer.WriteLine("Długość szlaku:");
                writer.WriteLine(lenght + " metrów" + "\n");
                writer.WriteLine("Opis:");
                writer.WriteLine(desc + "\n");
                writer.WriteLine("Oceny trudności:");
            }
            this.AddtoListOfNamesToFile();  
        }
        public MTrailsInFile()
          : base("NONE", "NONE", "NONE", 0)
        {
            
        }
        public override event GradeAddedDelegate GradeAdded;
        public string FileName;
        public override void DifficultyLevel(float grade)
        {
            if (grade > 0 && grade <= 5)
            {
                using (var writer = File.AppendText(this.FileName))
                {
                    writer.WriteLine(grade);
                }
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                
            }
            else throw new Exception("Value is too large or smaler than zero ");
            
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
            string lines = "";
            var statistics = new Statistics();
            List<float> grades = new List<float>();

            if (File.Exists(this.FileName))
            {
                using (var reader = File.OpenText(this.FileName))
                {                                       
                    while (lines != "Oceny trudności:")
                    {
                        lines = reader.ReadLine();
                    }
                    
                    lines = reader.ReadLine();
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
            else
                throw new Exception("File not exist !!!");

            return statistics;
        }

        public void AddtoListOfNamesToFile()
        {
            using(var writer = File.AppendText("ListOfNames.txt")) 
            {
                writer.WriteLine($" - {this.TrailName}");
            }
        }
           
    }
}

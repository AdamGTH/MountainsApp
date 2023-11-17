

using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static MyMountainApp.MTrailsBase;

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
                writer.WriteLine("Name:");
                writer.WriteLine(name+"\n");
                writer.WriteLine("Place:");
                writer.WriteLine(place + "\n");
                writer.WriteLine("Lenght of the meters:");
                writer.WriteLine(lenght + "\n");
                writer.WriteLine("Description:");
                writer.WriteLine(desc + "\n");
                writer.WriteLine("Grades:");
            }
            this.AddtoListOfNamesToFile();
            
        }
        public MTrailsInFile()
          : base("NONE", "NONE", "NONE", 0)
        {
            
        }

        public override event GradeAddedDelegate GradeAdded;
        List<float> Grades = new List<float>();
        public string FileName;
        public override void DifficultyLevel(float grade)
        {
            if (grade > 0 && grade <= 5)
            {
                using (var writer = File.AppendText(this.FileName))
                {
                    writer.WriteLine(grade);
                    this.Grades.Add(grade);
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
            
            if (File.Exists(this.FileName))
            {
                using (var reader = File.OpenText(this.FileName))
                {                                       
                    while (lines != "Grades:")
                    {
                        lines = reader.ReadLine();
                    }
                    
                    lines = reader.ReadLine();
                    while (lines != null)
                    {
                        this.Grades.Add(float.Parse(lines));
                        lines = reader.ReadLine();
                    }

                }
                foreach (var grade in this.Grades)
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
                writer.WriteLine($"{this.TrailName}");
            }
        }
           
    }
}

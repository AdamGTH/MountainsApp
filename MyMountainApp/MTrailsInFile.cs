

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
            else throw new Exception("Value is too large or smaller than zero ");
            
        }
        public override Statistics GetStatistics()
        {
            string line = "";
            var statistics = new Statistics();
            List<float> grades = new List<float>();    
            
            if (File.Exists(this.FileName))
            {
                using (var reader = File.OpenText(this.FileName))
                {                                       
                
                    line = reader.ReadLine();
                    while(line != null)
                    {
                        grades.Add(float.Parse(line));
                        line = reader.ReadLine();
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

                   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wheather
{   
    
    class Compute
    {
        File file { get; set; }
        List<WheatherLineData> WheatherLinesData;
        List<FootballLineData> FootballLinesData;

        public Compute(File file )
        {
            this.WheatherLinesData = new List<WheatherLineData>();
            this.FootballLinesData = new List<FootballLineData>();
            this.file = file;
        }

        void ParseWheatherFile()
        {
            for (int i = 2; i < file.lines.Length; i++)
            {
                WheatherLineData newLine = new WheatherLineData();
                string[] parsedLine = file.lines[i].Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                newLine.Dy = Decimal.Parse(parsedLine[0]);
                newLine.MxT = Decimal.Parse(parsedLine[1]);
                newLine.MnT = Decimal.Parse(parsedLine[2]);
                WheatherLinesData.Add(newLine);


            }
        }

        public void SmallestTempSpread()
        {
            ParseWheatherFile();
            decimal min = int.MaxValue;
            decimal spread;
            decimal day = -1;
            foreach (WheatherLineData line in WheatherLinesData)
            {
                spread = line.MxT - line.MnT;
                if (spread < min)
                {
                    min = spread;
                    day = line.Dy;
                }
            }
            Console.WriteLine("Day: " + day);
            Console.WriteLine("Minim temperature spread: " + min);
        }

        public void ParseFootballFile()
        {

            for (int i = 1; i < file.lines.Length; i++)
            {
                
                
                FootballLineData newLine = new FootballLineData();
                string[] parsedLine = file.lines[i].Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                
                Console.WriteLine(parsedLine[1]);
                newLine.TeamName = parsedLine[1];
                newLine.ForGoals = Int32.Parse(parsedLine[6]);
                newLine.AgainstGoals = Int32.Parse(parsedLine[7]);
                FootballLinesData.Add(newLine);


            }
        }

        public void SmallestGoalDiff()
        {
            ParseFootballFile();
            string TeamName="";
            int min = int.MaxValue;
            int diff;
            foreach (FootballLineData line in FootballLinesData)
            {
                if (line.AgainstGoals < line.ForGoals)
                    diff = line.ForGoals - line.AgainstGoals;
                else
                    diff = line.AgainstGoals - line.ForGoals;

                if(diff < min)
                {
                    min = diff;
                    TeamName = line.TeamName;
                }


            }
            Console.WriteLine("Team name: " + TeamName);
            Console.WriteLine("Minim goal difference: " + min);
        }
        
    }
}

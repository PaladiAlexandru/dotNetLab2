using System;

namespace wheather
{
    class Program
    {
        static void Main(string[] args)
        {
            File WheatherFile = new File(@"C:\temp\weather.dat");
            File FootballFile = new File(@"C:\temp\football.dat");

            WheatherFile.ReadFromFile();
            WheatherFile.RemoveUnwantedCharacter('*');
            FootballFile.ReadFromFile();
            FootballFile.RemoveUnwantedCharacter('-');

            Compute WheatherCompute = new Compute(WheatherFile);
           /* WheatherCompute.SmallestTempSpread();*/

            Compute FootballCompute = new Compute(FootballFile);
            FootballCompute.SmallestGoalDiff();
            

         
        }
    }
}

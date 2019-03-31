using System;
using System.Collections.Generic;

namespace CodeNationChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Challenge Results!");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Reader myReader = new Reader("./data.csv");
            MultiProcess myProcess = new MultiProcess(myReader.myInfo, myReader);
            myProcess.Run();

            watch.Stop();
            Console.WriteLine("\nTempo Transcorrido: " + watch.ElapsedMilliseconds +  " Milesegundos");
        }
    }
}

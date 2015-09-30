using CM.Assessment.Business;
using System;

namespace CM.Assessment.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GetRange range = new GetRange();
            range.ShowOutput += (s, e) =>
            {
                Console.WriteLine(e);
            };

            var input = new RunArgs(0, 150, "Fizz", "Buzz");
            range.Run(input);

            // OR
            //range.Run(1, 100, "Fizz", "Buzz");

            Console.ReadLine();
        }
    }
}

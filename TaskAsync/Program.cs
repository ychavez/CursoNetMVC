using System.Diagnostics;

namespace TaskAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<string> nombres = new();

            for (int i = 0; i < 100_000; i++)
            {
                nombres.Add(Guid.NewGuid().ToString());
            }


            Console.WriteLine("Iniciando desayunos");
            Stopwatch stopwatch = new();
            stopwatch.Start();

            var breakfastTasks = new List<Task>();

            foreach (var item in nombres)
            {
                breakfastTasks.Add(BreakFastClassic.DoBreakFastAsync(item));
            }


            await Task.WhenAll(breakfastTasks.ToArray());

            stopwatch.Stop();

            Console.WriteLine($"El desayuno esta listo y demoro {stopwatch.Elapsed}");


        }
    }
}

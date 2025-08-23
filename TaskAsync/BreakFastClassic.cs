using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAsync
{
    public class BreakFastClassic
    {

        public static void DoBreakFast(string client)
        {
            Coffe();
            HeatPan();
            FryEggs();
            FryBacon();
            ToastBread();
            Jam();
            Juice();
            Console.WriteLine($"El desayuno de {client} esta listo");
        }



        public static async Task DoBreakFastAsync(string client)
        {

            var toarBreadTask = ToastBreadAsync();
            var heatPanTask = HeatPanAsync();

            var cofeeTask = CoffeAsync();
            var juiceTask = JuiceAsync();

            await toarBreadTask;
            var jamTask = JamAsync();

            await heatPanTask;
            var fryEggsTask = FryEggsAsync();
            var fryBaconTask = FryBaconAsync();

            await cofeeTask;
            await juiceTask;
            await jamTask;
            await fryEggsTask;
            await fryBaconTask;

            Console.WriteLine($"El desayuno de {client} esta listo");

        }


        public static void Coffe()
        {
            Thread.Sleep(1000);
        }
        public static void HeatPan()
        {
            Thread.Sleep(1000);
        }
        public static void FryEggs()
        {
            Thread.Sleep(1000);
        }
        public static void FryBacon()
        {
            Thread.Sleep(1000);
        }
        public static void ToastBread()
        {
            Thread.Sleep(1000);
        }
        public static void Jam()
        {
            Thread.Sleep(1000);
        }

        public static void Juice()
        {
            Thread.Sleep(1000);
        }






        public static async Task CoffeAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Cafe terminado");
        }
        public static async Task HeatPanAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Sarten listo");

        }
        public static async Task FryEggsAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Huevo listo");
        }
        public static async Task FryBaconAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Tocino listo");
        }
        public static async Task ToastBreadAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Pan listo");
        }
        public static async Task JamAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Mermelada lista");
        }

        public static async Task JuiceAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Jugo listo");
        }

    }
}

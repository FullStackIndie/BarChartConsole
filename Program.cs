using Spectre.Console;
using System;

namespace BarChartConsole
{
    internal class Program
    {
        private static readonly BarChart _barChart = new();
        private static readonly BarChart _barChartStatic = new();
        private static readonly List<Fruit> itemsStatic = new()
            {
                new Fruit("Apple", Random.Shared.Next(3,10), Color.Yellow),
                new Fruit("Orange", Random.Shared.Next(2,8), Color.Red),
                new Fruit("Banana", Random.Shared.Next(1,9), Color.Green),
            };

        static void Main(string[] args)
        {
            Console.ReadKey();
            _barChartStatic.Data.AddRange(itemsStatic);
            for (int i = 0; i < 10; i++)
            {
                AddItems(i);
                Thread.Sleep(650);
            }
            Console.ReadKey();
        }

        public static void AddItems(int index)
        {
            var items = new List<Fruit>
                {
                    new Fruit("Apple", index  + Random.Shared.Next(4,20), Color.Yellow),
                    new Fruit("Orange", index + Random.Shared.Next(5,20), Color.Red),
                    new Fruit("Banana", index + Random.Shared.Next(6,20), Color.Green),
                };
            _barChart.Data.Clear();
            AnsiConsole.Console.Clear();
            AnsiConsole.WriteLine("Bar Chart Example");
            AnsiConsole.WriteLine();
            AnsiConsole.Write(_barChartStatic
                .Width(40)
                .Label("[green bold underline]Same number of fruits[/]")
                .CenterLabel());
            AnsiConsole.Write(_barChart
                .Width(100)
                .Label("[green bold underline]Updating number of fruits[/]")
                .CenterLabel()
                .AddItems(items));
        }

        public sealed class Fruit : IBarChartItem
        {
            public string Label { get; set; }
            public double Value { get; set; }
            public Color? Color { get; set; }

            public Fruit(string label, double value, Color? color = null)
            {
                Label = label;
                Value = value;
                Color = color;
            }
        }
    }
}

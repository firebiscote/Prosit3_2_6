using System;
using System.Collections.Generic;

namespace Prosit3_2_6
{
    public class ProductionLine : AbstractWorker
    {
        private readonly List<Unit> units;

        public ProductionLine(string name, List<Unit> units) : base(name)
        {
            for (int i = 0; i < units.Count - 1; i++)
                units[i].Next = units[i + 1];
            this.units = new List<Unit>(units);
        }

        public override void Process(object b = null)
        {
            DateTime start = DateTime.Now;

            units[0].Process();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} executed in {(DateTime.Now - start).TotalSeconds} seconds");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

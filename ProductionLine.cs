using System;
using System.Collections.Generic;

namespace Prosit3_2_6
{
    public class ProductionLine : AbstractWorker
    {
        public List<Unit> Units { get; set; }

        public ProductionLine(string name, List<Unit> units) : base(name)
        {
            for (int i = 0; i < units.Count - 1; i++)
                units[i].Next = units[i + 1];
            Units = new List<Unit>(units);
        }

        public override void Process(object b = null)
        {
            Units[0].Process();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} executed !");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

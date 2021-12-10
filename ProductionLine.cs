using System;
using System.Collections.Generic;
using System.Threading;

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
            Barrier barrier = new Barrier(participantCount: units.Count + 1);
            DateTime start = DateTime.Now;

            if (Monitor.TryEnter(units[0], 15000))
            {
                Thread t = new Thread(new ParameterizedThreadStart(units[0].Process));
                t.Start(barrier);
                Monitor.Exit(units[0]);
            }

            barrier.SignalAndWait();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} executed in {(DateTime.Now - start).TotalSeconds} seconds");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

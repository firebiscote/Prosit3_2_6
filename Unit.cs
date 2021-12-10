using System;
using System.Collections.Generic;
using System.Threading;

namespace Prosit3_2_6
{
    public class Unit : AbstractWorker
    {
        public IWorker Next { get; set; }
        private readonly List<IWorker> workers;

        public Unit(string name, List<IWorker> workers) : base(name) 
        {
            this.workers = new List<IWorker>(workers);
        }

        public override void Process(object b = null)
        {
            Barrier barrier = new Barrier(participantCount: workers.Count+1);
            DateTime start = DateTime.Now;

            foreach (IWorker worker in workers)
            {
                Thread t = new Thread(new ParameterizedThreadStart(worker.Process));
                t.Start(barrier);
            }
            barrier.SignalAndWait();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} executed in {(DateTime.Now - start).TotalSeconds} seconds !\n");
            Console.ForegroundColor = ConsoleColor.White;

            if (!(b is null))
                ((Barrier)b).SignalAndWait();

            if (!(Next is null))
                Next.Process();
        }
    }
}

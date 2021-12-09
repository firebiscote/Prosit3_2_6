using System;
using System.Collections.Generic;
using System.Threading;

namespace Prosit3_2_6
{
    public class Unit : AbstractWorker
    {
        public List<IWorker> Workers { get; set; }
        public IChainElement Next { get; set; }

        public Unit(string name, List<IWorker> workers, IChainElement next = null) : base(name) 
        {
            Workers = new List<IWorker>(workers);
            Next = next;
        }

        public override void Process(object b = null)
        {
            Barrier barrier = new Barrier(participantCount: Workers.Count+1);
            DateTime start = DateTime.Now;

            foreach (IWorker worker in Workers)
            {
                Thread t = new Thread(new ParameterizedThreadStart(worker.Process));
                t.Start(barrier);
            }
            barrier.SignalAndWait();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} executed in {(DateTime.Now - start).TotalMilliseconds} milliseconds !\n");
            Console.ForegroundColor = ConsoleColor.White;

            if (!(b is null))
                ((Barrier)b).SignalAndWait();

            if (!(Next is null))
                Next.Process();
        }
    }
}

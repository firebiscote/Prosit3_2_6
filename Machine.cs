using System;
using System.Threading;

namespace Prosit3_2_6
{
    public class Machine : AbstractWorker
    {
        public Machine(string name) : base(name) { }

        public override void Process(object b = null)
        {
            Random rnd = new Random();
            DateTime start = DateTime.Now;

            Thread.Sleep(rnd.Next(500, 5000));

            Console.WriteLine($"{Name} executed in {(DateTime.Now - start).TotalSeconds} seconds !");

            ((Barrier)b).SignalAndWait();
        }
    }
}

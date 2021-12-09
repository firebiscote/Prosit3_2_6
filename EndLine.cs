using System;

namespace Prosit3_2_6
{
    public class EndLine : IChainElement
    {
        public void Process(object b = null)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Chain executed !");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

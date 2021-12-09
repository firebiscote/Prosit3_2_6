using System.Collections.Generic;

namespace Prosit3_2_6
{
    class Program
    {
        static void Main()
        {
            EndLine end = new EndLine();
            Unit UT3 = new Unit(
                "UT3", 
                new List<IWorker>() 
                { 
                    new Unit("SUT1", new List<IWorker>() 
                    { 
                        new Machine("SUT1_Machine1"), 
                        new Machine("SUT1_Machine2"), 
                        new Machine("SUT1_Machine3") }), 
                    new Unit("SUT2", new List<IWorker>() 
                    { 
                        new Machine("SUT2_Machine1"), 
                        new Machine("SUT2_Machine2"), 
                        new Machine("SUT2_Machine3") 
                    }) 
                },
                end);

            Unit UT2 = new Unit(
                "UT2", 
                new List<IWorker>() 
                { 
                    new Machine("Machine") 
                },
                UT3);

            Unit UT1 = new Unit(
                "UT1", 
                new List<IWorker>() 
                { 
                    new Machine("Machine1"), 
                    new Machine("Machine2"), 
                    new Machine("Machine3") 
                },
                UT2);

            UT1.Process();
        }
    }
}

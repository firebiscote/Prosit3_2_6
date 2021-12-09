namespace Prosit3_2_6
{
    public abstract class AbstractWorker : IWorker
    {
        public string Name { get; set; }

        public AbstractWorker(string name)
        {
            Name = name;
        }

        public abstract void Process(object b = null);
    }
}

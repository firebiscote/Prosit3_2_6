namespace Prosit3_2_6
{
    public interface IWorker
    {
        public string Name { get; set; }

        public void Process(object o = null);
    }
}

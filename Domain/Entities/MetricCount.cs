namespace Domain.Entities
{
    public class MetricCount
    {
        public MetricCount(string description, int counter)
        {
            Description = description;
            Counter = counter;
        }

        public string Description { get; private set; }
        public int Counter { get; private set; }
    }
}

namespace Infrastructure.Generator
{
    public class ExcelEntity
    {
        public ExcelEntity(string description, int counter)
        {
            Description = description;
            Counter = counter;
        }

        public string Description { get; private set; }
        public int Counter { get; private set; }
    }
}

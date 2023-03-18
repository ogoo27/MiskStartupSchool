namespace MiskStartupSchool.Entities
{
    public class Details
    {
        public string Id { get; set; }
        public string ApplicationFormId { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
        public bool Current { get; set; } = false;
    }

    public class Education : Details
    {
        public string Name { get; set; }
        public string Course { get; set; }
        
    }

    public class Experience : Details
    {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

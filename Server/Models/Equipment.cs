namespace Server.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public int ToolId { get; set; }

        public string Info { get; set; }

        public decimal Price { get; set; }
    }
}
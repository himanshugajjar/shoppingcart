namespace ShoppingCartApp.Models
{
    public class Offer
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string[] ItemCodes { get; set; }
    }
}

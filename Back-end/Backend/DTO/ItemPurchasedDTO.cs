namespace Backend.DTO
{
    public class ItemPurchasedDTO
    {
        public int issue_id {  get; set; }
        public string description { get; set; }
        public string make { get; set; }        
        public string category { get; set; }
        public int valuation { get; set; }
    }
}

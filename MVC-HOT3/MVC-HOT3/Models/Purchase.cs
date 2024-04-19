namespace MVC_HOT3.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int PhoneID { get; set; }
        public Phone Phone { get; set; }
        public int Quantity { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? Total { get; set; }
    }
}

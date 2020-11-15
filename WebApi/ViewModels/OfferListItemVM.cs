using System;

namespace WebApi.ViewModels
{
    public class OfferListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public decimal MinPrice { get; set; }
        public PhotoCardVM PhotoCard { get; set; }
    }
}

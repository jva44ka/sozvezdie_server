using Domain.Interfaces;
using System;

namespace Domain.Models
{
    public class Offer : IDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string[] Route { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public decimal MinPrice { get; set; }
        public PhotoCard PhotoCard { get; set; }
        public PhotoCard[] PhotoAlbum { get; set; }
    }
}

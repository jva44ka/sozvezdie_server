﻿using System;

namespace WebApi.ViewModels
{
    public class OfferVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string[] Route { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public decimal MinPrice { get; set; }
        public PhotoCardVM PhotoCard { get; set; }
        public PhotoCardVM[] PhotoAlbum { get; set; }
    }
}

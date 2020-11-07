using Domain.Interfaces;

namespace Domain.Models
{
    public class PhotoCard : IDataModel
    {
        public string Photo { get; set; }
        public string Thumbnail { get; set; }
    }
}

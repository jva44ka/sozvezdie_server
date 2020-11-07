using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOfferManager
    {
        public Task<IEnumerable<Offer>> GetOffers();
        public Task<Offer> GetOfferById(int id);
    }
}

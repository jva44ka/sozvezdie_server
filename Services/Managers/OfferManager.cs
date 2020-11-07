using Domain.Interfaces;
using Domain.Models;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Managers
{
    public class OfferManager : IOfferManager
    {
        private readonly IRepository<Offer> _offerRepository;

        public OfferManager(IRepository<Offer> offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<IEnumerable<Offer>> GetOffers()
        {
            return await _offerRepository.GetAsync();
        }

        public async Task<Offer> GetOfferById(int id)
        {
            return await _offerRepository.GetByIdAsync(id);
        }
    }
}

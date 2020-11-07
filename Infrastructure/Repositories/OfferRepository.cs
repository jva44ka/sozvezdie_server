using Domain.Models;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OfferRepository : GenericRepository<Offer>
    {
        private readonly IDataReciveManager _dataReciveManager;
        private IEnumerable<Offer> _entities;

        public OfferRepository(IDataReciveManager dataReciveManager)
        {
            _dataReciveManager = dataReciveManager;
        }

        public override IEnumerable<Offer> Get() => GetEntities();

        public override async Task<IEnumerable<Offer>> GetAsync() => await GetEntitiesAsync();

        public override Offer GetById(int id)
        {
            return GetEntities().FirstOrDefault(o => o.Id == id);
        }

        public override async Task<Offer> GetByIdAsync(int id)
        {
            return (await GetEntitiesAsync()).FirstOrDefault(o => o.Id == id);
        }

        private IEnumerable<Offer> GetEntities()
        {
            if(_entities == null)
                _entities = _dataReciveManager.GetData<IEnumerable<Offer>>();

            return _entities;
        }

        private async Task<IEnumerable<Offer>> GetEntitiesAsync()
        {
            if (_entities == null)
                _entities = await _dataReciveManager.GetDataAsync<IEnumerable<Offer>>();

            return _entities;
        }
    }
}

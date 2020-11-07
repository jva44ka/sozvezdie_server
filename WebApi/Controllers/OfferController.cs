using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferManager _offerManager;

        public OfferController(IOfferManager offerManager)
        {
            _offerManager = offerManager;
        }
        // GET: api/<OfferController>
        [HttpGet]
        public async Task<IEnumerable<Offer>> Get()
        {
            return await _offerManager.GetOffers();
        }

        // GET api/<OfferController>/5
        [HttpGet("{id}")]
        public async Task<Offer> GetById(int id)
        {
            return await _offerManager.GetOfferById(id);
        }
    }
}

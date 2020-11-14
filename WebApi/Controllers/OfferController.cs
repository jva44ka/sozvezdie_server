using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferManager _offerManager;
        private readonly IMapper _mapper;

        public OfferController(IOfferManager offerManager, IMapper mapper)
        {
            _offerManager = offerManager;
            _mapper = mapper;
        }

        // GET: api/<OfferController>
        [HttpGet]
        public async Task<IEnumerable<OfferListItemVM>> Get()
        {
            return _mapper.Map<IList<OfferListItemVM>>(await _offerManager.GetOffers());
        }

        // GET api/<OfferController>/5
        [HttpGet("{id}")]
        public async Task<OfferVM> GetById(int id)
        {
            return _mapper.Map<OfferVM>(await _offerManager.GetOfferById(id));
        }
    }
}

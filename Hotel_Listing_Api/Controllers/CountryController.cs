using AutoMapper;
using Hotel_Listing_Api.DTO_Models;
using Hotel_Listing_Api.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Listing_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await _unitOfWork.countries.GetAll();
                var returnList = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(returnList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetAllCountries)}");
                return StatusCode(500, "Internal server error, Please try again later.....");
            }
        }

        [HttpGet]
        [Route("GetCountryById")]
        public async Task<IActionResult> GetCountryById(int countryId)
        {
            try
            {
                var countryObj = await _unitOfWork.countries.Get(x => x.Id == countryId, new List<string> { "Hotels" });
                if (countryObj == null)
                {
                    return Ok("Invalid Id, No data found !!");
                }
                var returnObj = _mapper.Map<CountryDTO>(countryObj);
                return Ok(returnObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Internal error in {nameof(GetCountryById)}");
                return StatusCode(500, "Internal server error, Please try again later....." + "---" + ex);
            }
        }
    }
}

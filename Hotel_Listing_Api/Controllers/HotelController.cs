using AutoMapper;
using Hotel_Listing_Api.DTO_Models;
using Hotel_Listing_Api.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Listing_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<HotelController> _logger;

        public HotelController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HotelController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllHotels")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                var hotels = await _unitOfWork.hotels.GetAll();
                var mapperHotels = _mapper.Map<IList<HotelDTO>>(hotels);
                return Ok(mapperHotels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetAllHotels)}");
                return StatusCode(500, "Internal server error, Please try again later.....");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetHotelById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotelById(int hotelId)
        {
            try
            {
                var hotel = await _unitOfWork.hotels.Get(x => x.Id == hotelId, new List<string> { "Country" });
                if (hotel == null)
                {
                    return NotFound();
                }
                var hotelObj = _mapper.Map<HotelDTO>(hotel);
                return Ok(hotelObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Internal error in {nameof(GetHotelById)}");
                return StatusCode(500, "Internal server error, Please try again later....." + "---" + ex);
                // return BadRequest();
            }
        }
    }
}

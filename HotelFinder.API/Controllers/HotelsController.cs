using HotelFinder.Business.Abstract;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//Bu validation-lari yoxluyur
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelServices)
        {
            _hotelService = hotelServices;
        }

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var hotels = _hotelService.GetAllHotel();
            return Ok(hotels);
        }
        /// <summary>
        /// Get the Hotel with Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{action}/{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel != null)
                return Ok(hotel);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("{action}/{name}")]
        public IActionResult GetHotelByName(string name)
        {
            var hotel = _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }

        // 2 parametr alacagsa bu sekilde olacag
        [HttpGet]
        [Route("{action}/{id}/{name}")]
        public IActionResult GetHotelByIdAndName(int id,string name)
        {
            return Ok();
        }
        /// <summary>
        /// Create Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{action}")]
        public IActionResult Create([FromBody] Hotel hotel)
        {
            var createdHotels = _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = createdHotels.Id }, createdHotels);//CreatedAtAction bu gonderilen responsun header-nini mueyyen edir
        }
        /// <summary>
        /// Update Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{action}")]
        public IActionResult Update(Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UptadeHotel(hotel));
            }
            return NotFound();
        }
        /// <summary>
        /// Delete Hotel with Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("{action}/{id}")]
        public IActionResult Delete(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
        }
    }
}

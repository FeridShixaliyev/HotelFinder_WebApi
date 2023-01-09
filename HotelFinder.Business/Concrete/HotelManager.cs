using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System.Collections.Generic;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public Hotel CreateHotel(Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public void DeleteHotel(int id)
        {
             _hotelRepository.DeleteHotel(id);
        }

        public List<Hotel> GetAllHotel()
        {
            return _hotelRepository.GetAllHotel();
        }

        public Hotel GetHotelById(int id)
        {
            return _hotelRepository.GetHotelById(id);
        }

        public Hotel GetHotelByName(string name)
        {
            return _hotelRepository.GetHotelByName(name);
        }

        public Hotel UptadeHotel(Hotel hotel)
        {
            return _hotelRepository.UptadeHotel(hotel);
        }
    }
}

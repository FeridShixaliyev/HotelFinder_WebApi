using HotelFinder.Entities;
using System.Collections.Generic;

namespace HotelFinder.Business.Abstract
{
    public interface IHotelService
    {
        List<Hotel> GetAllHotel();

        Hotel GetHotelById(int id);
        Hotel GetHotelByName(string name);

        Hotel CreateHotel(Hotel hotel);

        Hotel UptadeHotel(Hotel hotel);

        void DeleteHotel(int id);
    }
}

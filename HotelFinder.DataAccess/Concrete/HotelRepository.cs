using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                hotelDbContext.SaveChanges();   
                return hotel;
            }
        }

        public void DeleteHotel(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                Hotel deleteHotel=hotelDbContext.Hotels.Find(id);    
                hotelDbContext.Hotels.Remove(deleteHotel);
                hotelDbContext.SaveChanges();
            }
        }

        public List<Hotel> GetAllHotel()
        {
            using(var hotelDbContext=new HotelDbContext())
            {
                return hotelDbContext.Hotels.ToList();  
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.Find(id);
            }
        }

        public Hotel GetHotelByName(string name)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.FirstOrDefault(h=>h.Name.ToLower()==name.ToLower());
            }
        }

        public Hotel UptadeHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                Hotel hotel1 = hotelDbContext.Hotels.FirstOrDefault(h => h.Id==hotel.Id);
                hotel1.Name=hotel.Name;
                hotel1.City=hotel.City;
                hotelDbContext.SaveChanges();
                return hotel1;
            }
        }
    }
}

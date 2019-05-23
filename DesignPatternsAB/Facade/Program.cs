using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsAB
{
    // 1. Система орендування черевиків
    class SkiRent
    {
        public int RentBoots(int feetSize, int skierLevel)
        {
            return 20;
        }
        public int RentSki(int weight, int skierLevel)
        {
            return 40;
        }
        public int RentPole(int height)
        {
            return 5;
        }
    }

    // 2. Система придбання квитків
    class SkiResortTicketSystem
    {
        public int BuyOneDayTicket()
        {
            return 115;
        }
        public int BuyHalfDayTicket()
        {
            return 60;
        }
    }
    // 3. Система бронювання місць в готелі
    class HotelBookingSystem
    {
        public int BookRoom(int roomQuality)
        {
            switch (roomQuality)
            {
                case 3:
                    return 250;
                case 4:
                    return 500;
                case 5:
                    return 900;
                default:
                    throw new ArgumentException(
                        "roomQuality should be in range [3;5]");
            }
        }
    }
    // Фасад, що надає єдиний доступ до всіх систем згаданих вище
    class SkiResortFacade
    {
        private SkiRent _skiRent = new SkiRent();
        private SkiResortTicketSystem _skiResortTicketSystem
            = new SkiResortTicketSystem();
        private HotelBookingSystem _hotelBookingSystem = new HotelBookingSystem();
        
        // Беручи до уваги вхідні параметри бронює номер, підбирає лижі і т.д
        // Повертає загальну ціну за все
        public int HaveGoodRest(int height, int weight, int feetSize, int skierLevel,
            int roomQuality)
        {
            int skiPrice = _skiRent.RentSki(weight, skierLevel);
            int skiBootsPrice = _skiRent.RentBoots(feetSize, skierLevel);
            int polePrice = _skiRent.RentPole(height);
            int oneDayTicketPr = _skiResortTicketSystem.BuyOneDayTicket();
            int hotelPrice = _hotelBookingSystem.BookRoom(roomQuality);
            return skiPrice + skiBootsPrice + polePrice + oneDayTicketPr + hotelPrice;
        }
        // Інші методи можуть поєднувати виклики до інших систем
        public int HaveRestWithOwnSkis()
        {
            int oneDayTicketPrice = _skiResortTicketSystem.BuyOneDayTicket();
            return oneDayTicketPrice;
        }
        // Може бути що наш фасад-термінал просто огортає методи із усіх систем
    }

}

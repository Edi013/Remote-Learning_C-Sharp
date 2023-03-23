using iQuest.HotelQueries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.HotelQueries
{
    public class Hotel
    {
        public List<Room> Rooms { get; set; } = new List<Room>();

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        /// <summary>
        /// 1) Return a collection with all rooms that can accomodate exactly 2 persons.
        /// </summary>
        public IEnumerable<Room> GetAllRoomsForTwoPersons()
        {
            var rooms = Rooms
                .Where(x => x.MaxPersonCount == 2);

            return rooms;
        }

        /// <summary>
        /// 2) Return all customers whose full name contains the specified searched text.
        /// The search must be case insensitive.
        /// </summary>
        public IEnumerable<Customer> FindCustomerByName(string text)
        {
            IEnumerable<Customer> customers = Customers
                .Where(client => client.FullName.ToLower().Contains(text.ToLower()));
         
            return customers;
        }

        /// <summary>
        /// 3) Return all reservations made by companies.
        /// </summary>
        public IEnumerable<Reservation> GetCompanyReservations()
        {
            var companyCustomers = Reservations
                .Select(x => x.Customer)
                .OfType<CompanyCustomer>();

            var reservations = Reservations
                .Where(reservation => companyCustomers.Contains(reservation.Customer));

            return reservations;
        }

        /// <summary>
        /// 4) Return all women customers that last checked in a specific period of time.
        /// </summary>
        public IEnumerable<Customer> FindWomen(DateTime startTime, DateTime endTime)
        {
            var womenCustomers = Customers
                .OfType<PersonCustomer>()
                .Where(x => x.Gender.Equals(PersonGender.Female)
                && x.LastAccommodation >= startTime 
                && x.LastAccommodation <= endTime);

            return womenCustomers;
        }

        /// <summary>
        /// 5) Calculate how many persons can the hotel accomodate.
        /// </summary>
        public int CalculateHotelCapacity()
        {
            int hotelCapacity = Rooms
                .Select(x => x.MaxPersonCount)
                .Sum();

            return hotelCapacity;
        }

        /// <summary>
        /// 6) Return a single page containing a number of exactly pageSize Rooms, ordered by surface.
        /// The pageNumber starts from 0.
        ///
        /// This is useful when paginating a large number of items in order to display them in a webpage.
        /// </summary>
        public IEnumerable<Room> GetPageOfRoomsOrderedBySurface(int pageNumber, int pageSize)
        {
            return Rooms
                .OrderBy(x => x.Surface)
                .Skip(pageNumber * pageSize)
                .Take(pageSize);

            /* # Query sintax :
             * var roomsOrderedBySurface = (from room in Rooms
                                         orderby room.Surface
                                         select room).ToList();

            List<Room> page = new List<Room>();
            for (int i = 0; i < roomsOrderedBySurface.Count(); i++)
                if (pageNumber * pageSize <= i && i < pageNumber * pageSize + pageSize)
                    page.Add(roomsOrderedBySurface[i]);

            return page;*/
        }

        /// <summary>
        /// 7) Return the rooms sorted by <see cref="Room.MaxPersonCount"/> in a descending order.
        /// If two rooms have the same number of max persons, sort them further by <see cref="Room.Number"/> in ascending order.
        /// </summary>
        public IEnumerable<Room> GetRoomsOrderedByCapacity()
        {
            var roomsOrderedByCapacity = Rooms
                .OrderByDescending(room => room.MaxPersonCount)
                .ThenBy(room => room.Number);

            return roomsOrderedByCapacity;

            /* # Query sintax :
             * var roomsOrderedByCapacity = from room in Rooms
                                        orderby room.MaxPersonCount descending, room.Number ascending
                                        select room;

            return roomsOrderedByCapacity;*/
        }

        /// <summary>
        /// 8) Return all reservations for the specified customer.
        /// The reservations must be ordered from the most recent one to the oldest one.
        /// </summary>
        public IEnumerable<Reservation> GetReservationsOrderedByDateFor(int customerId)
        {
            var reservationsOrderedByDateForCustomer =
                Reservations
                .Where(reservation => reservation.Customer.Id == customerId)
                .OrderByDescending(reservation => reservation.StartDate)
                .ThenByDescending(reservation => reservation.EndDate);

            return reservationsOrderedByDateForCustomer;

            /* Query sintax
             * var reservationsOrderedByDateForCustomer = from reservation in Reservations
                                        where reservation.Customer.Id == customerId
                                        orderby reservation.StartDate descending, reservation.EndDate descending
                                        select reservation;

            return reservationsOrderedByDateForCustomer;*/

        }

        /// <summary>
        /// 9) Return a dictionary with the customers grouped by the last accommodation's year.
        /// The years must be enumerated in descending order.
        /// Customers must be ordered by full name.
        /// </summary>
        public List<KeyValuePair<int, Customer[]>> GetCustomersGroupedByYear()
        {
            return Customers
            .GroupBy(x => x.LastAccommodation.Year)
            .OrderByDescending(x => x.Key)
            .Select(x => new KeyValuePair<int, Customer[]>(x.Key, x.OrderBy(z => z.FullName).ToArray()))
            .ToList();
        }

        /// <summary>
        /// 10) Calculate the average number of reservation per month.
        /// Consider the start date as the date of the reservation.
        /// </summary>
        public double CalculateAverageReservationsPerMonth()
        {
            var average = Reservations
                .GroupBy(rezervare => rezervare.StartDate.Month)
                .Average(grup => grup.Count());

            return average;
        }

        /// <summary>
        /// 11) Find all reservations that have a conflict with other ones and return a dictionary containing the reservation as key
        /// and the list of conflicting reservations as value.
        /// The reservations that does not have conflicts should not be present in the dictionary.
        /// </summary>
        public IDictionary<Reservation, List<Reservation>> GetConflictingReservations()
        {
            var dictionary = new Dictionary<Reservation, List<Reservation>>();

           Reservations
                .Where(eachReservation => Reservations.FindAll(x => x.ConflictsWith(eachReservation)).Any())
                .ToList()
                .ForEach(eachReservation => dictionary.Add(eachReservation,Reservations.FindAll(x => x.ConflictsWith(eachReservation))));
           
            return dictionary;
        }

        /// <summary>
        /// 12) We have a reservation for a room, but there is a conflict: there is another reservation for the same room.
        /// Your task is to propose another similar room for the reservation.
        /// 
        /// A similar room is a room that has the same number of maximum occupants or grater, has air conditioner if
        /// the original reserved room had, is disabled friendly if the original reserved room was and
        /// has balcony if the original reserved room had one.
        /// </summary>
        public Room FindNewFreeRoomFor(Reservation reservation)
        {
            var similarRooms = Rooms
               .Where(room => room.IsInUse == false)
               .Where(room => reservation.Room.MaxPersonCount <= room.MaxPersonCount)
               .Where(room => reservation.Room.HasAirConditioner ? room.HasAirConditioner == true : room.HasAirConditioner == false)
               .Where(room => reservation.Room.HasBalcony ? room.HasBalcony == true : room.HasBalcony == false)
               .Where(room => reservation.Room.IsDisabledFriendly ? room.IsDisabledFriendly == true : room.IsDisabledFriendly == false)
               .Where(room => Reservations.Where(eachReservation => eachReservation.ConflictsWith(reservation) == true)
                                          .Select(eachReservation => eachReservation.Room)
                                          .Where(eachRoom => eachRoom.Equals(room))
                                          .Any() == false);
            if (!similarRooms.Any())
                return null;

            return similarRooms.First();
            /* Query sintax : 
             * var similarRooms = from room in Rooms
                                where room.IsInUse == false
                                where room.MaxPersonCount >= reservation.Room.MaxPersonCount
                                where reservation.Room.HasAirConditioner ? room.HasAirConditioner == true : room.HasAirConditioner == false
                                where reservation.Room.HasBalcony ? room.HasBalcony == true : room.HasBalcony == false
                                where reservation.Room.IsDisabledFriendly ? room.IsDisabledFriendly == true : room.IsDisabledFriendly == false
                                select room;
            */
        }
    }
}
using System;
using System.Collections.Generic;
using iQuest.HotelQueries.Domain;
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
            var rooms =   (from r in Rooms
                           where r.MaxPersonCount == 2
                           select r).ToList();
            return rooms;
        }

        /// <summary>
        /// 2) Return all customers whose full name contains the specified searched text.
        /// The search must be case insensitive.
        /// </summary>
        public IEnumerable<Customer> FindCustomerByName(string text)
        {
            IEnumerable<Customer> customers = from client in Customers
                                              where client.FullName.ToLower().Contains(text.ToLower())
                                              select client;
            return customers;
        }
        
        /// <summary>
        /// 3) Return all reservations made by companies.
        /// </summary>
        public IEnumerable<Reservation> GetCompanyReservations()
        {
            var reservations = (from reservation in Reservations
                               where reservation.Customer.GetType() == typeof(CompanyCustomer)
                               select reservation).ToList();

            return reservations;
        }

        /// <summary>
        /// 4) Return all women customers that last checked in a specific period of time.
        /// </summary>
        public IEnumerable<Customer> FindWomen(DateTime startTime, DateTime endTime)
        {
            IEnumerable<Customer> customers = from customer in Customers
                                              where startTime <= customer.LastAccommodation
                                              where customer.LastAccommodation <= endTime
                                              where customer.GetType() == typeof(PersonCustomer)
                                              where (customer as PersonCustomer).Gender.Equals(PersonGender.Female)
                                              select customer;
                                              
            return customers;
        }

        /// <summary>
        /// 5) Calculate how many persons can the hotel accomodate.
        /// </summary>
        public int CalculateHotelCapacity()
        {
            int hotelCapacity = (from room in Rooms
                                select room.MaxPersonCount).Sum();

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
            var roomsOrderedBySurface =  (from room in Rooms
                                         orderby room.Surface
                                         select room).ToList();

            List<Room> page = new List<Room>();
            for(int i = 0; i<roomsOrderedBySurface.Count(); i++)
                if (pageNumber * pageSize <= i && i < pageNumber * pageSize + pageSize)
                    page.Add(roomsOrderedBySurface[i]);

            return page;
        }

        /// <summary>
        /// 7) Return the rooms sorted by <see cref="Room.MaxPersonCount"/> in a descending order.
        /// If two rooms have the same number of max persons, sort them further by <see cref="Room.Number"/> in ascending order.
        /// </summary>
        public IEnumerable<Room> GetRoomsOrderedByCapacity()
        {
            var roomsOrderedBySurface = (from room in Rooms
                                         orderby room.MaxPersonCount descending, room.Number ascending 
                                         select room).ToList();

            return roomsOrderedBySurface;
        }

        /// <summary>
        /// 8) Return all reservations for the specified customer.
        /// The reservations must be ordered from the most recent one to the oldest one.
        /// </summary>
        public IEnumerable<Reservation> GetReservationsOrderedByDateFor(int customerId)
        {
            var roomsOrderedBySurface = (from reservation in Reservations
                                         where reservation.Customer.Id == customerId
                                         orderby reservation.StartDate descending, reservation.EndDate descending
                                         select reservation).ToList();

            return roomsOrderedBySurface;
        }

        /// <summary>
        /// 9) Return a dictionary with the customers grouped by the last accommodation's year.
        /// The years must be enumerated in descending order.
        /// Customers must be ordered by full name.
        /// </summary>
        public List<KeyValuePair<int, Customer[]>> GetCustomersGroupedByYear()
        {
            List<KeyValuePair<int, List<Customer>>> customersGroupedUsingList = new List<KeyValuePair<int, List<Customer>>>();
            
            var years = Enumerable.Range(2010, 2018 - 2009).ToArray();
            foreach (int year in years)
                customersGroupedUsingList.Add(new KeyValuePair<int, List<Customer>>(year, new List<Customer>()));

            foreach (var customer in Customers)
            {
                int lastYearOfAccomodation = customer.LastAccommodation.Year;

                foreach(var pair in customersGroupedUsingList)
                {
                    if(pair.Key == lastYearOfAccomodation)
                    {
                        pair.Value.Add(customer);
                        break;
                    }
                }
            }

            //sort customers by FullName
            // aux list is required 'cause KeyValuePair.Value is readonly
            List<KeyValuePair<int, List<Customer>>> auxList = new List<KeyValuePair<int, List<Customer>>>();
            foreach (var pair in customersGroupedUsingList)
            {
                auxList.Add(new KeyValuePair<int, List<Customer>>
                    (pair.Key, pair.Value.OrderBy(x => x.FullName).ToList() ));
            }
            customersGroupedUsingList = auxList;
            auxList = null;

            //sort years descending
            customersGroupedUsingList = customersGroupedUsingList.OrderByDescending(x => x.Key).ToList();

            //Create the returned type ( List<KeyValuePair<int, Customer[]>> )
            // and map actual type ( List<KeyValuePair<int, List<Customer>>> ) to it.
            List<KeyValuePair<int, Customer[]>> customersGroupedByYear = new List<KeyValuePair<int, Customer[]>>();
            foreach(var pair in customersGroupedUsingList)
            {
                customersGroupedByYear.Add(new KeyValuePair<int, Customer[]>(pair.Key, new Customer[pair.Value.Count]));
                for(int i = 0; i < pair.Value.Count; i++)
                {
                    customersGroupedByYear.Last().Value[i] = pair.Value[i];
                }
            }
            return customersGroupedByYear;
        }

        /// <summary>
        /// 10) Calculate the average number of reservation per month.
        /// Consider the start date as the date of the reservation.
        /// </summary>
        public double CalculateAverageReservationsPerMonth()
        {
            throw new NotImplementedException();
            /*double numberOfReservations = Reservations.Count();
            double numberOfMonths = 12 * (2018 - 2009);
            List<int> a = new List<int>();
            a.Average(12, 1234)

            double averageReservationsPerMonth = numberOfReservations / numberOfMonths;
            return averageReservationsPerMonth;*/
            //grupam rezervarile pe 
            var a = Reservations
                .GroupBy(rezervare => rezervare.StartDate.Month)
                .Average(grup => grup.Key);

            Console.ReadLine();
            return 1.1;
        }

        /// <summary>
        /// 11) Find all reservations that have a conflict with other ones and return a dictionary containing the reservation as key
        /// and the list of conflicting reservations as value.
        /// The reservations that does not have conflicts should not be present in the dictionary.
        /// </summary>
        public IDictionary<Reservation, List<Reservation>> GetConflictingReservations()
        {
            Dictionary<Reservation, List<Reservation>> conflictingReservations 
                = new Dictionary<Reservation, List<Reservation>>();

            foreach(Reservation reservation1 in Reservations)
            {
                foreach (Reservation reservation2 in Reservations)
                {
                    if (reservation1.ConflictsWith(reservation2))
                    {
                        if (conflictingReservations.ContainsKey(reservation1))
                        {
                            conflictingReservations[reservation1].Add(reservation2);
                            continue;
                        }
                        conflictingReservations.Add(reservation1, new List<Reservation>() { reservation2 });

                    }
                }
            }

            return conflictingReservations;
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
            var similarRooms = (from room in Rooms
                                where room.IsInUse == false
                                where room.MaxPersonCount >= reservation.Room.MaxPersonCount 
                                where reservation.Room.HasAirConditioner  ? room.HasAirConditioner  == true : room.HasAirConditioner  == false
                                where reservation.Room.HasBalcony         ? room.HasBalcony         == true : room.HasBalcony         == false
                                where reservation.Room.IsDisabledFriendly ? room.IsDisabledFriendly == true : room.IsDisabledFriendly == false
                                select room).ToList();

            if (!similarRooms.Any())
                return null;
            return similarRooms[0];
        }
    }
}
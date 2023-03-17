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
            IEnumerable<Customer> customer = from client in Customers
                                             where client.FullName   == text
                                             select client;
            return customer;
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
            IEnumerable<Customer> customers = (from reservation in Reservations
                                              where reservation.StartDate >= startTime && reservation.EndDate <= endTime
                                              && reservation.Customer.GetType() == typeof(PersonCustomer) 
                                              && (reservation.Customer as PersonCustomer).Gender.ToString() == "Female"
                                              select reservation.Customer).ToList();
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
            var roomsOrderedBySurface = (from room in Rooms
                                         orderby room.Surface descending
                                         select room).ToList();

            return roomsOrderedBySurface;
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
            
            var years = Enumerable.Range(2010, 2019 - 2010).ToArray();
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
        }

        /// <summary>
        /// 11) Find all reservations that have a conflict with other ones and return a dictionary containing the reservation as key
        /// and the list of conflicting reservations as value.
        /// The reservations that does not have conflicts should not be present in the dictionary.
        /// </summary>
        public IDictionary<Reservation, List<Reservation>> GetConflictingReservations()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
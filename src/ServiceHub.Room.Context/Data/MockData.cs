using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceHub.Room.Context.Models;

namespace ServiceHub.Room.Context.Data
{
    class MockData
    {
        private List<Models.Room> _data;
        private Models.Address _address;
        private Models.Room _room;
        public MockData()
        {
            _data = new List<Models.Room>();
        }

        public IEnumerable<Models.Room> getSeedData()
        {
            return LoadData(_data);
        }

        public IEnumerable<Models.Room> LoadData(List<Models.Room> newList)
        {
            _address = new Address
            {
                Address1 = "2919 Network pl.",
                Address2 = "101",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33559",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "M",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "2919 Network pl.",
                Address2 = "102",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33559",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "M",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "2919 Network pl.",
                Address2 = "201",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33559",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "F",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "2919 Network pl.",
                Address2 = "301",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33559",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "F",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            //12977 50th St, Tampa, FL 33617
            _address = new Address
            {
                Address1 = "12977 50th St.",
                Address2 = "210",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33617",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "F",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "12977 50th St.",
                Address2 = "224",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33617",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "F",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);
     
            _address = new Address
            {
                Address1 = "12977 50th St.",
                Address2 = "107",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33617",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "M",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "12977 50th St.",
                Address2 = "210",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33617",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "F",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "12977 50th St.",
                Address2 = "310",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33617",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "M",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "12977 50th St.",
                Address2 = "113",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33617",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "M",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "12977 50th St.",
                Address2 = "410",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33617",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "F",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "12977 50th St.",
                Address2 = "405",
                AddressId = new Guid(),
                City = "Tampa",
                Country = "US",
                PostalCode = "33617",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "F",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            //15420 Livingston Ave, Lutz, FL 33559
            _address = new Address
            {
                Address1 = "15420 Livingston Ave.",
                Address2 = "123",
                AddressId = new Guid(),
                City = "Lutz",
                Country = "US",
                PostalCode = "33559",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "F",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "15420 Livingston Ave.",
                Address2 = "201",
                AddressId = new Guid(),
                City = "Lutz",
                Country = "US",
                PostalCode = "33559",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "M",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "15420 Livingston Ave.",
                Address2 = "303",
                AddressId = new Guid(),
                City = "Lutz",
                Country = "US",
                PostalCode = "33559",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "F",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);

            _address = new Address
            {
                Address1 = "15420 Livingston Ave.",
                Address2 = "117",
                AddressId = new Guid(),
                City = "Lutz",
                Country = "US",
                PostalCode = "33559",
                State = "FL"
            };
            _room = new Models.Room
            {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = _address,
                Gender = "F",
                Occupancy = 4,
                Vacancy = 4
            };
            newList.Add(_room);
            return newList;
        }
    }
}

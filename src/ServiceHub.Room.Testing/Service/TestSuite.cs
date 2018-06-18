using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xunit;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Models;

namespace ServiceHub.Room.Testing.Service
{
    public class TestSuite
    {

        private RoomRepositoryMemory _context;
        private readonly Address _address;
        private readonly Room.Context.Models.Room _room;

        public TestSuite()
        {
            _address = _address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            _room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = _address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };
        }

        [Fact]
        public void TestModelProperties()
        {
            Address address1 = new Address();
            address1.AddressId = _address.AddressId;
            address1.Address1 = _address.Address1;
            address1.Address2 = _address.Address2;
            address1.City = _address.City;
            address1.State = _address.State;
            address1.Country = _address.Country;
            address1.PostalCode = _address.PostalCode;

            Room.Context.Models.Room room1 = new Room.Context.Models.Room();

            room1.RoomId = _room.RoomId;
            room1.Address = _room.Address;
            room1.Location = _room.Location;
            room1.Occupancy = _room.Occupancy;
            room1.Vacancy = _room.Vacancy;
            room1.Gender = _room.Gender;

           
            var obj1ToJSON = _room.ToJson();
            var obj2ToJSON = _room.ToJson();

            Assert.Equal(obj1ToJSON,obj2ToJSON);
        }

        [Fact]
        public async Task TestContextInsert()
        {
            _context = new RoomRepositoryMemory();
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };

            _context.InsertAsync(room);

            Assert.Equal(room.RoomId, _context.GetAsync().Result[0].RoomId);

        }
        
        [Fact]
        public async Task TestGetAll()
        {
            _context = new RoomRepositoryMemory();
            List<Room.Context.Models.Room> results;
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };

            Address address1 = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "4321 Tester ava.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room1 = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address1,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };


            await _context.InsertAsync(room);
            await _context.InsertAsync(room1);
            results = _context.GetAsync().Result;

            Assert.Equal(2,results.Count);
        }

        [Fact]
        public async Task TestGetByID()
        {
            _context = new RoomRepositoryMemory();
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };

            await _context.InsertAsync(room);
            Room.Context.Models.Room result = _context.GetByIdAsync(room.RoomId).Result;


            Assert.Equal(room.RoomId,result.RoomId);
        }

        [Fact]
        public async Task TestUpdate()
        {
            _context = new RoomRepositoryMemory();
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };

            _context.InsertAsync(room);

            room.Location = "Dallas";
            _context.UpdateAsync(room);

            Assert.Equal("Dallas",_context.GetByIdAsync(room.RoomId).Result.Location);

        }

        [Fact]
        public async Task TestDelete()
        {
            _context = new RoomRepositoryMemory();
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };

            await _context.InsertAsync(room);
            
            await _context.DeleteAsync(room.RoomId);

            Assert.Empty(_context.roomList);
        }
    }
}

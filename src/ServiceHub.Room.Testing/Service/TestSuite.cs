using System;
using System.Collections.Generic;
using Xunit;
using ServiceHub.Room.Context;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Models;

namespace ServiceHub.Room.Testing.Service
{
    public class TestSuite
    {
        private RoomRepositoryMemory context;

        [Fact]
        public void TestContextInsert()
        {
            context = new RoomRepositoryMemory();
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

            context.Insert(room);

            Assert.Equal(room.RoomId, context.Get()[0].RoomId);
        }



        [Fact]
        public void TestGetAll()
        {
            context = new RoomRepositoryMemory();
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

            context.Insert(room);
            context.Insert(room1);
            results = context.Get();
            Assert.Equal(2,results.Count);
        }

        [Fact]
        public void TestGetByID()
        {
            context = new RoomRepositoryMemory();
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
            context.Insert(room);
            Room.Context.Models.Room result = context.GetById(room.RoomId);

            Assert.Equal(room.RoomId,result.RoomId);
        }

        [Fact]
        public void TestUpdate()
        {
            context = new RoomRepositoryMemory();
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
            context.Insert(room);

            room.Vacancy = 0;
            context.Update(room);

            Assert.Equal(0,context.GetById(room.RoomId).Vacancy);
        }

        [Fact]
        public void TestDelete()
        {
            context = new RoomRepositoryMemory();
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
            context.Insert(room);

            //room.Vacancy = 0;
            context.Delete(room.RoomId);

            Assert.Empty(context.roomList);
        }
    }
}

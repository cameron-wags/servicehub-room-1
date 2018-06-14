using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ServiceHub.Room.Context.Models;
using ServiceHub.Room.Service.Controllers;
using ServiceHub.Room.Context.Repository;
using Xunit;

namespace ServiceHub.Room.Testing.Service
{
    public class RoomControllerTest
    {
        private Address address;
        private Room.Context.Models.Room room;
        private RoomRepositoryMemory context;

        public RoomControllerTest()
        {
            context = new RoomRepositoryMemory();
            address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            room = new Room.Context.Models.Room
            {
                RoomId = Guid.NewGuid(),
                Address = address,
                Location = "Tampa",
                Vacancy = 1,
                Occupancy = 2,
                Gender = "M"
            };
        }

        [Fact]
        public async void TestControllerGet()
        {
            //Arrange
            room.Address = address;
            Guid id = room.RoomId;
            context.Insert(room);
            RoomController roomController = new RoomController(null,null,context);

            //Act
            //var response = await roomController.Get();
            var myTask = Task.Run(() => roomController.Get());
            var result = await myTask;
            var contentResult = result as OkObjectResult;


            var list = contentResult.Value as List<Room.Library.Models.Room>;
            Guid id1 = list[0].RoomId;

            Assert.Equal(id,id1);

        }

        [Fact]
        public async void TestControllerGetById()
        {
            //Arrange
            room.Address = address;
            Guid id = room.RoomId;
            context.Insert(room);
            RoomController roomController = new RoomController(null, null, context);

            var myTask = Task.Run(() => roomController.Get(id));
            var result = await myTask;
            var contentResult = result as OkObjectResult;

            var roomReturned = contentResult.Value as Room.Library.Models.Room;

            Assert.Equal(id,roomReturned.RoomId);
        }
    }
}

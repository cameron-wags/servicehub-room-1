using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceHub.Room.Context.Models;
using ServiceHub.Room.Service.Controllers;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Utilities;
using Xunit;

namespace ServiceHub.Room.Testing.Service
{
    public class RoomControllerTest
    {
        private Room.Library.Models.Address address;
        private Room.Library.Models.Room room;
        private RoomRepositoryMemory context;

        public RoomControllerTest()
        {
            context = new RoomRepositoryMemory();
            address = new Room.Library.Models.Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            room = new Room.Library.Models.Room
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
            context.Insert(ModelMapper.LibraryToContext(room));
            RoomController roomController = new RoomController(new LoggerFactory(), context);

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
            context.Insert(ModelMapper.LibraryToContext(room));
            RoomController roomController = new RoomController(new LoggerFactory(), context);

            var myTask = Task.Run(() => roomController.Get(id));
            var result = await myTask;
            var contentResult = result as OkObjectResult;

            var roomReturned = contentResult.Value as Room.Library.Models.Room;

            Assert.Equal(id,roomReturned.RoomId);
        }

        [Fact]
        public async void TestControllerPost()
        {
            //Arrange
            room.Address = address;
            RoomController roomController = new RoomController(new LoggerFactory(), context);

            //Act
            var myTask = Task.Run(() => roomController.Post(room));
            var result = await myTask;

            var contentResult = result as OkObjectResult;
            Assert.NotNull(contentResult.StatusCode);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code,200,300);
        }
    }
}

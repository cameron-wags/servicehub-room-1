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
using StatusCodeResult = Microsoft.AspNetCore.Mvc.StatusCodeResult;

namespace ServiceHub.Room.Testing.Service
{
    public class RoomControllerTest
    {
        private readonly Room.Library.Models.Address _address;
        private readonly Room.Library.Models.Room _room;
        private readonly RoomRepositoryMemory _context;

        public RoomControllerTest()
        {
            _context = new RoomRepositoryMemory();
            _address = new Room.Library.Models.Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            _room = new Room.Library.Models.Room
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
        public async Task TestControllerGet()
        {
            //Arrange
            _room.Address = _address;
            Guid id = _room.RoomId;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            RoomController roomController = new RoomController(new LoggerFactory(), _context);

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
        public async Task TestControllerGetById()
        {
            //Arrange
            _room.Address = _address;
            Guid id = _room.RoomId;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            RoomController roomController = new RoomController(new LoggerFactory(), _context);

            var myTask = Task.Run(() => roomController.Get(id));
            var result = await myTask;
            var contentResult = result as OkObjectResult;

            var roomReturned = contentResult.Value as Room.Library.Models.Room;

            Assert.Equal(id,roomReturned.RoomId);
        }

        [Fact]
        public async Task TestControllerGetByIdWithInvalidArgument()
        {
            //Arrange
            _room.Address = _address;
            Guid id = _room.RoomId;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            RoomController roomController = new RoomController(new LoggerFactory(), _context);

            var myTask = Task.Run(() => roomController.Get(Guid.Empty));
            var result = await myTask;
           

            var contentResult = result as StatusCodeResult;
            //var contentResult = result as OkObjectResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code, 500, 599);
        }

        [Fact]
        public async Task TestControllerPost()
        {
            //Arrange
            _room.Address = _address;
            RoomController roomController = new RoomController(new LoggerFactory(), _context);

            //Act
            var myTask = Task.Run(() => roomController.Post(_room));
            var result = await myTask;

            var contentResult = result as StatusCodeResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code,200,300);
        }

        [Fact]
        public async Task TestPostwithInValidModel()
        {
            _room.Address = _address;
            var roomController = new RoomController(new LoggerFactory(), _context);
            // make Room model invalid
            _room.Location = null;

            //Act
            var myTask = Task.Run(() => roomController.Post(_room));
            var result = await myTask;

            var contentResult = result as StatusCodeResult;
            Assert.NotNull(contentResult);
            var code = contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }

        [Fact]
        public async Task TestControllerPut()
        {
            //Arrange
            RoomController roomController = new RoomController(new LoggerFactory(), _context);
            _room.Address = _address;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            _room.Location = "Dallas";

            var myTask = Task.Run(() => roomController.Put(_room));
            var result = await myTask;

            //var contentResult = result as StatusCodeResult;
            var contentResult = result as OkObjectResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code, 200, 299);
            Room.Context.Models.Room room1 = _context.GetById(_room.RoomId);
            Assert.Equal("Dallas", room1.Location);
        }

        [Fact]
        public async Task TestControllerPutWithTwoArguments()
        {
            //Arrange
            RoomController roomController = new RoomController(new LoggerFactory(), _context);
            _room.Address = _address;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            _room.Location = "Dallas";

            var myTask = Task.Run(() => roomController.Put(_room.RoomId,_room));
            var result = await myTask;

            //var contentResult = result as StatusCodeResult;
            var contentResult = result as OkObjectResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code, 200, 299);
            Room.Context.Models.Room room1 = _context.GetById(_room.RoomId);
            Assert.Equal("Dallas", room1.Location);
        }

        [Fact]
        public async Task TestPutwithInValidModel()
        {
            _room.Address = _address;
            var roomController = new RoomController(new LoggerFactory(), _context);
            // make Room model invalid
            _room.RoomId = Guid.Empty;

            //Act
            var myTask = Task.Run(() => roomController.Put(_room));
            var result = await myTask;

            //var contentResult = result as StatusCodeResult;
            //var contentResult = result as OkObjectResult;
            var contentResult = result as BadRequestObjectResult;
            Assert.NotNull(contentResult);
            var code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }

        [Fact]
        public async Task TestControllerDelete()
        {
            //Arrange
            RoomController roomController = new RoomController(new LoggerFactory(), _context);
            _room.Address = _address;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            
            Assert.NotEmpty(_context.roomList);
            var myTask = Task.Run(() => roomController.Delete(_room.RoomId));
            var result = await myTask;

            var contentResult = result as StatusCodeResult;
            //var contentResult = result as OkObjectResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;            
            Assert.InRange(code, 200, 300);
            Assert.Empty(_context.roomList);
        }

        
    }
}


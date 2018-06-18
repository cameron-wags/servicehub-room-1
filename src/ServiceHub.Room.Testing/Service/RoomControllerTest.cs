﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
<<<<<<< HEAD
            _room.Address = _address;
            Guid id = _room.RoomId;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            RoomController roomController = new RoomController(new LoggerFactory(), _context);
=======
            room.Address = address;
            Guid id = room.RoomId;
            await context.InsertAsync(ModelMapper.LibraryToContext(room));
            RoomController roomController = new RoomController(new LoggerFactory(), context);
>>>>>>> origin/dev

            //Act
            var myTask = roomController.Get();
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
<<<<<<< HEAD
            _room.Address = _address;
            Guid id = _room.RoomId;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            RoomController roomController = new RoomController(new LoggerFactory(), _context);
=======
            room.Address = address;
            Guid id = room.RoomId;
            await context.InsertAsync(ModelMapper.LibraryToContext(room));
            RoomController roomController = new RoomController(new LoggerFactory(), context);
>>>>>>> origin/dev

            var myTask = roomController.Get(id);
            var result = await myTask;
            var contentResult = result as OkObjectResult;

            var roomReturned = contentResult.Value as Room.Library.Models.Room;

            Assert.Equal(id,roomReturned.RoomId);
        }

        [Fact]
        public async Task TestControllerGetByIdWithInvalidArgument()
        {
            //Arrange
<<<<<<< HEAD
            _room.Address = _address;
            Guid id = _room.RoomId;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            RoomController roomController = new RoomController(new LoggerFactory(), _context);
=======
            room.Address = address;
            Guid id = room.RoomId;
            await context.InsertAsync(ModelMapper.LibraryToContext(room));
            RoomController roomController = new RoomController(new LoggerFactory(), context);
>>>>>>> origin/dev

            var myTask = roomController.Get(Guid.Empty);
            var result = await myTask;
           

            var contentResult = result as BadRequestObjectResult;
            
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code, 400, 499);
        }

        [Fact]
        public async Task TestControllerPost()
        {
            //Arrange
            _room.Address = _address;
            RoomController roomController = new RoomController(new LoggerFactory(), _context);

            //Act
<<<<<<< HEAD
            var myTask = Task.Run(() => roomController.Post(_room));
=======
            var myTask = roomController.Post(room);
>>>>>>> origin/dev
            var result = await myTask;

            var contentResult = result as CreatedAtRouteResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code,200,299);
        }

        [Fact]
        public async Task TestPostwithInValidModel()
        {
            _room.Address = _address;
            var roomController = new RoomController(new LoggerFactory(), _context);
            // make Room model invalid
            _room.Location = null;

            //Act
<<<<<<< HEAD
            var myTask = Task.Run(() => roomController.Post(_room));
=======
            var myTask = roomController.Post(room);
>>>>>>> origin/dev
            var result = await myTask;

            var contentResult = result as BadRequestObjectResult;
            Assert.NotNull(contentResult);
            var code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }

        [Fact]
        public async Task TestControllerPut()
        {
            //Arrange
<<<<<<< HEAD
            RoomController roomController = new RoomController(new LoggerFactory(), _context);
            _room.Address = _address;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            _room.Location = "Dallas";

            var myTask = Task.Run(() => roomController.Put(_room));
=======
            RoomController roomController = new RoomController(new LoggerFactory(), context);
            room.Address = address;
            await context.InsertAsync(ModelMapper.LibraryToContext(room));
            room.Location = "Dallas";

            var myTask = roomController.Put(room);
>>>>>>> origin/dev
            var result = await myTask;

            //var contentResult = result as StatusCodeResult;
            var contentResult = result as NoContentResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code, 200, 299);
<<<<<<< HEAD
            Room.Context.Models.Room room1 = _context.GetById(_room.RoomId);
=======
            Room.Context.Models.Room room1 = context.GetByIdAsync(room.RoomId).Result;
>>>>>>> origin/dev
            Assert.Equal("Dallas", room1.Location);
        }

        [Fact]
        public async Task TestControllerPutWithTwoArguments()
        {
            //Arrange
<<<<<<< HEAD
            RoomController roomController = new RoomController(new LoggerFactory(), _context);
            _room.Address = _address;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            _room.Location = "Dallas";

            var myTask = Task.Run(() => roomController.Put(_room.RoomId,_room));
=======
            RoomController roomController = new RoomController(new LoggerFactory(), context);
            room.Address = address;
            await context.InsertAsync(ModelMapper.LibraryToContext(room));
            room.Location = "Dallas";

            var myTask = roomController.Put(room.RoomId,room);
>>>>>>> origin/dev
            var result = await myTask;
            
            var contentResult = result as NoContentResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            Assert.InRange(code, 200, 299);
<<<<<<< HEAD
            Room.Context.Models.Room room1 = _context.GetById(_room.RoomId);
=======
            Room.Context.Models.Room room1 = context.GetByIdAsync(room.RoomId).Result;
>>>>>>> origin/dev
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
<<<<<<< HEAD
            var myTask = Task.Run(() => roomController.Put(_room));
=======
            var myTask = roomController.Put(room);
>>>>>>> origin/dev
            var result = await myTask;
            
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
<<<<<<< HEAD
            RoomController roomController = new RoomController(new LoggerFactory(), _context);
            _room.Address = _address;
            _context.Insert(ModelMapper.LibraryToContext(_room));
            
            Assert.NotEmpty(_context.roomList);
            var myTask = Task.Run(() => roomController.Delete(_room.RoomId));
=======
            RoomController roomController = new RoomController(new LoggerFactory(), context);
            room.Address = address;
            await context.InsertAsync(ModelMapper.LibraryToContext(room));
            
            Assert.NotEmpty(context.roomList);
            var myTask = roomController.Delete(room.RoomId);
>>>>>>> origin/dev
            var result = await myTask;

            var contentResult = result as StatusCodeResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;            
<<<<<<< HEAD
            Assert.InRange(code, 200, 300);
            Assert.Empty(_context.roomList);
=======
            Assert.InRange(code, 200, 299);
            Assert.Empty(context.roomList);
>>>>>>> origin/dev
        }
        [Fact]
        public async void TestControllerDeleteWithNullModel()
        {
            //Arrange
            RoomController roomController = new RoomController(new LoggerFactory(), context);
            room.Address = address;
            await context.InsertAsync(ModelMapper.LibraryToContext(room));

            Assert.NotEmpty(context.roomList);
            var badId = Guid.Empty;
            var myTask = roomController.Delete(badId);
            var result = await myTask;

            var contentResult = result as BadRequestObjectResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }
        [Fact]
        public async void TestControllerDeleteWithModelNotInData()
        {
            //Arrange
            RoomController roomController = new RoomController(new LoggerFactory(), context);
            room.Address = address;
            await context.InsertAsync(ModelMapper.LibraryToContext(room));

            Assert.NotEmpty(context.roomList);
            var badId = Guid.NewGuid();
            var myTask = roomController.Delete(badId);
            var result = await myTask;

            var contentResult = result as NotFoundObjectResult;
            Assert.NotNull(contentResult);
            int code = (int)contentResult.StatusCode;
            //Invalid input is a client side fault which should yeild a 4xx status code
            Assert.InRange(code, 400, 499);
        }

    }
}
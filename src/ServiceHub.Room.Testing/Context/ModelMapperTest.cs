using System;
using System.Collections.Generic;
using ServiceHub.Room.Context.Utilities;
using ServiceHub.Room.Library.Models;
using Xunit;

namespace ServiceHub.Room.Testing.Context {
    
    public class LibToContextRoomTests {

        [Fact]
        public void NullParameter() {
            Room.Library.Models.Room nullRoom = null;

            var actual = ModelMapper.LibraryToContext(nullRoom);

            Assert.Null(actual);
        }

        [Fact]
        public void EmptyModelInput() {
            var invalidModel = new Room.Library.Models.Room();

            var actual = ModelMapper.LibraryToContext(invalidModel);

            Assert.Null(actual);
        }

        [Fact]
        public void ValidModelInput() {
            var validModel = new Room.Library.Models.Room() {
                RoomId = new Guid(),
                Location = "Tampa",
                Address = new Address() {
                    AddressId = new Guid(),
                    Address1 = "123 Street Ln",
                    Address2 = "",
                    City = "Lutz",
                    State = "FL",
                    PostalCode = "33412",
                    Country = "US"
                },
                Vacancy = 4,
                Occupancy = 6,
                Gender = "M"
            };

            var actual = ModelMapper.LibraryToContext(validModel);

            Assert.Equal(validModel.ToString(), actual.ToString());
        }
    }

    public class RoomContextToLibTests {
        [Fact]
        public void NullParameter() {
            Room.Context.Models.Room nullRoom = null;

            var actual = ModelMapper.ContextToLibrary(nullRoom);

            Assert.Null(actual);
        }

        [Fact]
        public void EmptyModelInput() {
            Room.Context.Models.Room emptyRoom = new Room.Context.Models.Room();

            var actual = ModelMapper.ContextToLibrary(emptyRoom);

            Assert.Null(actual);
        }

        [Fact]
        public void ValidModelInput() {
            var validModel = new Room.Context.Models.Room() {RoomId = new Guid(),
                Location = "Tampa",
                Address = new Room.Context.Models.Address() {
                    AddressId = new Guid(),
                    Address1 = "123 Street Ln",
                    Address2 = "",
                    City = "Lutz",
                    State = "FL",
                    PostalCode = "33412",
                    Country = "US"
                },
                Vacancy = 4,
                Occupancy = 6,
                Gender = "M"
            };

            var actual = ModelMapper.ContextToLibrary(validModel);

            Assert.Equal(validModel.ToString(), actual.ToString());
        }
    }

    public class RoomListContextToLibTests {
        [Fact]
        public void NullParameter() {
            List<Room.Context.Models.Room> nullList = null;

            var actual = ModelMapper.ContextToLibrary(nullList);

            Assert.Null(actual);
        }

        [Fact]
        public void EmptyParameter() {
            List<Room.Context.Models.Room> emptyList = new List<Room.Context.Models.Room>();

            var actual = ModelMapper.ContextToLibrary(emptyList);

            Assert.Empty(actual);
        }
    }

    public class AddressLibToContextTests {
        [Fact]
        public void NullParameter() {

        }
    }

    public class AddressContextToLibTests {
        [Fact]
        public void NullParameter() {

        }
    }
}
using System;
using ServiceHub.Room.Context.Utilities;
using ServiceHub.Room.Library.Models;
using Xunit;

namespace ServiceHub.Room.Testing.Context {
    
    public class LibToContextRoomTests {

        [Fact]
        public void NullParameter() {
            var actual = ModelMapper.LibraryToContext(null);

            Assert.Null(actual);
        }

        [Fact]
        public void InvalidModelInput() {
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

        }
    }

    public class RoomListContextToLibTests {
        [Fact]
        public void NullParameter() {

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
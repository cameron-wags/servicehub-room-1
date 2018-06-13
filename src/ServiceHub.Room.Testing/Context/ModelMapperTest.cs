using ServiceHub.Room.Context.Utilities;
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
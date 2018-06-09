using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using ServiceHub.Room.Library;
using Xunit;
namespace ServiceHub.Room.Testing.Library
{
    public class TestSuite
    {
        [Fact]
        public void TestRoomValidationAll()
        {
            //Arrange
            Room.Library.Room room = new Room.Library.Room();

            //Act
            //var validationResults = new List<ValidationResult>();
            //var actual = Validator.TryValidateObject(room, new ValidationContext(room), validationResults, true);

            // Assert
            //Assert.False(actual);
            Assert.False(room.isValidState(room));
        }

        [Fact]
        public void TestRoomValidationLocation()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Room
            {
                //RoomId = new Guid(),
                RoomId = Guid.NewGuid(),
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = GenderEnum.Male
            };

            //Act
            //var validationResults = new List<ValidationResult>();
            //var actual = Validator.TryValidateObject(room, new ValidationContext(room), validationResults, true);

            //Assert
            //Assert.False(actual);
            Assert.False(room.isValidState(room));
        }

        [Fact]
        public void TestRoomValidationPasses()

        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Room
            {
                //RoomId = new Guid(),
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = GenderEnum.Male
            };

            //Act
            //var validationResults = new List<ValidationResult>();
            //var actual = Validator.TryValidateObject(room, new ValidationContext(room), validationResults, true);

            //Assert
            //Assert.False(!actual);
            Assert.True(room.isValidState(room));
        }

        [Fact]
        public void TestRoomValidationNoAddress()

        {
            var room = new Room.Library.Room
            {
                //RoomId = new Guid(),
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                //Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = GenderEnum.Male
            };

            //Act
            //var validationResults = new List<ValidationResult>();
            //var actual = Validator.TryValidateObject(room, new ValidationContext(room), validationResults, true);

            //Assert
            //Assert.False(actual);
            Assert.False(room.isValidState(room));
        }

        [Fact]
        public void TestRoomValidationWithInvalidAddress()
        {
            //Arrange
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                //Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Room
            {
                //RoomId = new Guid(),
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = GenderEnum.Male
            };

            Assert.False(room.isValidState(room));
        }

        [Fact]
        public void TestRoomValidationWithInvalidAddress1()
        {
            //Arrange
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                //City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Room
            {
                //RoomId = new Guid(),
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = GenderEnum.Male
            };

            Assert.False(room.isValidState(room));
        }

        [Fact]
        public void TestRoomValidationVacancy()

        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Room
            {
                //RoomId = new Guid(),
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                //Vacancy = 1,
                Occupancy = 2,
                Gender = GenderEnum.Male
            };

            //Act
            //var validationResults = new List<ValidationResult>();
            //var actual = Validator.TryValidateObject(room, new ValidationContext(room), validationResults, true);

            //Assert
            //Assert.False(actual);
            Assert.False(room.isValidState(room));
        }

        [Fact]
        public void TestRoomValidationVacancyGreaterThanOccupancy()
        {
            //Arrange
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Room
            {
                //RoomId = new Guid(),
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 3,
                Occupancy = 2,
                Gender = GenderEnum.Male
            };

            Assert.False(room.isValidState(room));
        }

        [Fact]
        public void TestRoomValidationOccupancy()

        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Room
            {
                //RoomId = new Guid(),
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 1,
                //Occupancy = 2,
                Gender = GenderEnum.Male
            };

            //Act
            //var validationResults = new List<ValidationResult>();
            //var actual = Validator.TryValidateObject(room, new ValidationContext(room), validationResults, true);

            //Assert
            //Assert.False(actual);
            Assert.False(room.isValidState(room));
        }

        [Fact]
        public void TestRoomValidationOccupancyLessThanZero()

        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Room
            {
                //RoomId = new Guid(),
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 0,
                Occupancy = 0,
                Gender = GenderEnum.Male
            };




            //Assert
            Assert.False(room.isValidState(room));
        }

        [Fact]
        public void TestRoomValidationGender()

        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Room
            {
                //RoomId = new Guid(),
                RoomId = Guid.NewGuid(),
                Location = "Tampa",
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                //Gender = "M"
            };

            //Act
            //var validationResults = new List<ValidationResult>();
            //var actual = Validator.TryValidateObject(room, new ValidationContext(room), validationResults, true);

            //Assert
            //Assert.False(actual);
            Assert.False(room.isValidState(room));
        }

        [Fact]
        public void TestRoomValidationLocationLimit()

        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            var room = new Room.Library.Room
            {
                //RoomId = new Guid(),
                RoomId = Guid.NewGuid(),
                Location = "Lorem ipsum dolor sit amet, nonummy ligula volutpat hac integer nonummy. " +
                           "Suspendisse ultricies, congue etiam tellus, erat libero, nulla eleifend, mauris " +
                           "pellentesque. Suspendisse integer praesent vel, integer gravida mauris, fringilla " +
                           "vehicula lacinia non 1",
                Address = address,
                Vacancy = 1,
                Occupancy = 2,
                Gender = GenderEnum.Male
            };

            //Act
            //var validationResults = new List<ValidationResult>();
            //var actual = Validator.TryValidateObject(room, new ValidationContext(room), validationResults, true);

            //Assert
            //Assert.False(actual);
            Assert.False(room.isValidState(room));
        }

        [Fact]
        public void TestAddressValidationAll()

        {
            //Arange
            Address address = new Address();

            //Act
            //var validationResults = new List<ValidationResult>();
            //var actual = Validator.TryValidateObject(address, new ValidationContext(address), validationResults, true);

            //Assert
            //Assert.False(actual);
            Assert.False(address.isValidState(address));
        }

        [Fact]
        public void TestAddressValidationAddressId()

        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            //Act
            //var validationResults = new List<ValidationResult>();
            //var actual = Validator.TryValidateObject(address, new ValidationContext(address), validationResults, true);

            //Assert
            //Assert.False(actual);
            Assert.False(address.isValidState(address));
        }

        [Fact]
        public void TestAddressValidationAddress1()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                //Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            //Act
            //var validationResults = new List<ValidationResult>();
            //var actual = Validator.TryValidateObject(address, new ValidationContext(address), validationResults, true);
            //string reason = "";
            //try
            //{
            //    reason = validationResults[0].ErrorMessage;
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    //Force Failure
            //    Assert.True(false, "Model:address unexpectedly passed validation");
            //}

            ////Assert
            //Assert.False(actual);
            //Assert.Contains("Address1 field is required", reason);
            Assert.False(address.isValidState(address));
        }
        [Fact]
        public void TestAddressValidationAddress2()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                //Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            //Act & Assert

            Assert.False(address.isValidState(address));
        }
        [Fact]
        public void TestAddressValidationCity()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                //City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            //Act & Assert

            Assert.False(address.isValidState(address));
        }
        [Fact]
        public void TestAddressValidationState()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                //State = "Ca"
            };

            //Act & Assert

            Assert.False(address.isValidState(address));
        }

        [Fact]
        public void TestAddressValidationStateToLong()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "Cal"
            };

            //Act & Assert

            Assert.False(address.isValidState(address));
        }

        [Fact]
        public void TestAddressValidationStateToShort()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "92646",
                State = "C"
            };

            //Act & Assert

            Assert.False(address.isValidState(address));
        }

        [Fact]
        public void TestAddressValidationPostalCode()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                //PostalCode = "92646",
                State = "Ca"
            };

            //Act & Assert

            Assert.False(address.isValidState(address));
        }

        [Fact]
        public void TestAddressValidationPostalCodeToLong()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "926464",
                State = "Ca"
            };

            //Act & Assert

            Assert.False(address.isValidState(address));
        }

        [Fact]
        public void TestAddressValidationPostalCodeToShort()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USA",
                PostalCode = "9264",
                State = "Ca"
            };

            //Act & Assert

            Assert.False(address.isValidState(address));
        }

        [Fact]
        public void TestAddressValidationCountry()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                //Country = "USA",
                PostalCode = "92646",
                State = "Ca"
            };

            //Act & Assert

            Assert.False(address.isValidState(address));
        }

        [Fact]
        public void TestAddressValidationCountryToLong()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USAa",
                PostalCode = "92646",
                State = "Ca"
            };

            //Act & Assert

            Assert.False(address.isValidState(address));
        }

        [Fact]
        public void TestAddressValidationCountryToShort()
        {
            //Arange
            Address address = new Address
            {
                //AddressId = new Guid(),
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            //Act & Assert

            Assert.False(address.isValidState(address));
        }

    }
}

using System;
using ServiceHub.Room.Library.Models;
using Xunit;

namespace ServiceHub.Room.Testing.Library
{
    public class AddressTest
    {
        [Fact]
        public void TestAddressValidationAll()
        {
            var address = new Address();
            
            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationAddressId()
        {
            var address = new Address
            {
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationAddress1()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                //Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationAddress1ToLong()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "THIS STRING IS 256 CHARACTERS xxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                           "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                           "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                           "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                           "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };
            Assert.False(address.isValidState());
        }


        [Fact]
        public void TestAddressValidationAddress2()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                //Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.True(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationAddress2ToLong()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "THIS STRING IS 256 CHARACTERS xxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                           "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                           "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                           "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                           "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };

            Assert.False(address.isValidState());
        }

        [Fact]
        public void TestAddressValidationCity()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                //City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationState()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                //State = "Ca"
            };
            
            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationStateToLong()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "Cal"
            };
            
            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationStateToShort()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "C"
            };

            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationPostalCode()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                //PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationPostalCodeToLong()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "926464",
                State = "Ca"
            };
            
            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationPostalCodeToShort()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "9264",
                State = "Ca"
            };
            
            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationCountry()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                //Country = "US",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationCountryToLong()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "USa",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationCountryToShort()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "U",
                PostalCode = "92646",
                State = "Ca"
            };
            
            Assert.False(address.IsValidState());
        }

        [Fact]
        public void TestAddressValidationInvalidState()
        {
            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                Address1 = "1234 Test st.",
                Address2 = "apt 303",
                City = "Tampa",
                Country = "US",
                PostalCode = "92646",
                State = "CW"
            };

            Assert.False(address.isValidState());
        }
    }
}

using System;
using System.Collections.Generic;
using ServiceHub.Room.Context.Models;

namespace ServiceHub.Room.Context.Utilities
{
    /// <summary>
    /// Provides mapping between the context and library models.
    /// </summary>
    public static class ModelMapper
    {
        /// <summary>
        /// Converts a library room to a context room.
        /// </summary>
        /// <param name="libraryRoom">Library model Room</param>
        /// <exception cref="InvalidCastException">If given model is invalid and cannot be mapped.</exception>
        /// <returns>Converted Room context model.</returns>
        public static Models.Room LibraryToContext(Library.Models.Room libraryRoom) {
            if (!libraryRoom.isValidState()) {
                throw new InvalidCastException(message: "Cannot cast invalid model.");
            }

            return new Models.Room() {
                RoomId = libraryRoom.RoomId,
                Location = libraryRoom.Location,
                Address = LibraryToContext(libraryRoom.Address),
                Vacancy = libraryRoom.Vacancy.Value,
                Occupancy = libraryRoom.Occupancy.Value,
                Gender = libraryRoom.Gender
            };
        }

        /// <summary>
        /// Converts a context room to a library room.
        /// </summary>
        /// <param name="contextRoom">Context model Room</param>
        /// <exception cref="InvalidCastException">If given model is invalid and cannot be mapped.</exception>
        /// <returns>Converted Room library model.</returns>
        public static Library.Models.Room ContextToLibrary(Models.Room contextRoom) {
            var libRoom = new Library.Models.Room() {
                RoomId = contextRoom.RoomId,
                Location = contextRoom.Location,
                Address = ContextToLibrary(contextRoom.Address),
                Vacancy = contextRoom.Vacancy,
                Occupancy = contextRoom.Occupancy,
                Gender = contextRoom.Gender
            };

            if (!libRoom.isValidState()) {
                throw new InvalidCastException(message: "Resulting model is invalid.");
            }

            return libRoom;
        }

        /// <summary>
        /// Converts a list of context rooms to a list of library rooms.
        /// </summary>
        /// <param name="contextRooms">A list of context model Rooms.</param>
        /// <exception cref="InvalidCastException">If a model in the list is invalid and cannot be mapped.</exception>
        /// <returns>List of converted Room library models.</returns>
        public static List<Library.Models.Room> ContextToLibrary(List<Models.Room> contextRooms) {
            List<Library.Models.Room> result = new List<Library.Models.Room>();

            foreach (var room in contextRooms) {
                result.Add(ContextToLibrary(room));
            }

            return result;
        }

        /// <summary>
        /// Converts a library address to a context address.
        /// </summary>
        /// <param name="libraryAddress">A library Address model.</param>
        /// <exception cref="InvalidCastException">If the model is invalid and cannot be mapped.</exception>
        /// <returns>A converted Address context model.</returns>
        private static Models.Address LibraryToContext(Library.Models.Address libraryAddress) {
            if (!libraryAddress.isValidState()) {
                throw new InvalidCastException(message: "Cannot cast invalid model.");
            }

            return new Address() {
                AddressId = libraryAddress.AddressId,
                Address1 = libraryAddress.Address1,
                Address2 = libraryAddress.Address2,
                City = libraryAddress.City,
                State = libraryAddress.State,
                PostalCode = libraryAddress.PostalCode,
                Country = libraryAddress.Country
            };
        }

        /// <summary>
        /// Converts a context address to a library address.
        /// </summary>
        /// <param name="contextAddress">A context Address model.</param>
        /// <exception cref="InvalidCastException">If the model is invalid and cannot be mapped.</exception>
        /// <returns>A converted Address library model.</returns>
        private static Library.Models.Address ContextToLibrary(Models.Address contextAddress) {
            var libAddress = new Library.Models.Address() {
                AddressId = contextAddress.AddressId,
                Address1 = contextAddress.Address1,
                Address2 = contextAddress.Address2,
                City = contextAddress.City,
                State = contextAddress.State,
                PostalCode = contextAddress.PostalCode,
                Country = contextAddress.Country
            };

            if (!libAddress.isValidState()) {
                throw new InvalidCastException(message: "Resulting model is invalid.");
            }

            return libAddress;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceHub.Room.Library
{
    public class Room

    {
        public Guid RoomId { get; set; }

        public string Location { get; set; }

        public Address Address { get; set; }

        public int Vacancy { get; set; }

        public int Occupancy { get; set; }

        public char Gender { get; set; }

    }
}

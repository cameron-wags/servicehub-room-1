using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceHub.Room.Library
{
    //<summary> Room model. </summary>
    public class Room

    {
        //<summary> Key. Used to uniquely identify this Room model. </summary>
        public Guid RoomId { get; set; }
        //<summary> Name of the trainning location where this room is
        //located.  Example: "Reston", "Tampa" or, "Dallas".
        //</summary>
        public string Location { get; set; }
        //<summary> This Address model for this room. </summary>
        public Address Address { get; set; }
        //<summary> Number of unassigned beds in this room. </summary>
        public int Vacancy { get; set; }
        //<summary> Total number of beds in this room weather assigned or not</summary>
        public int Occupancy { get; set; }
        //<summary> Sex that this room accommodates.
        // Usage: 'M' or 'F'. Mutually exclusive.
        //</summary>
        public char Gender { get; set; }

    }
}

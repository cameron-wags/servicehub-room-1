using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace ServiceHub.Room.Library
{
    //<summary> Room model. </summary>
    public class Room
    {
        //<summary> Key. Used to uniquely identify this Room model. </summary>

        public Guid RoomId { get; set; }
        //<summary> Name of the training location where this room is
        //located.  Example: "Reston", "Tampa" or, "Dallas".
        //</summary>
        [StringLength(255)]
        public string Location { get; set; }
        //<summary> This Address model for this room. </summary>
        public Address Address { get; set; }
        //<summary> Number of unassigned beds in this room. </summary>
        public int? Vacancy { get; set; }
        //<summary> Total number of beds in this room weather assigned or not</summary>
        public int? Occupancy { get; set; }
        //<summary> Sex that this room accommodates. </summary>\
        public GenderEnum? Gender { get; set; }

        //<summary> Method for checking if state of model is valid </summary>
        public bool isValidState(Room model)
        {
            if (RoomId == System.Guid.Empty) { return false; }
            if (Location == null || Location.Length > 255) { return false; }
            if (Address == null || !Address.isValidState(this.Address)) { return false; }
            if (Vacancy == null || Vacancy > Occupancy) { return false; }
            if (Occupancy == null || Occupancy <= 0) { return false; }
            if (Gender == null) { return false; }

            return true;

        }
    }

    [DataContract(Name = "Gender")]
    public enum GenderEnum
    {
        [EnumMember]
        Male,
        [EnumMember]
        Female


    }
}

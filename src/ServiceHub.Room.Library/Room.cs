using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceHub.Room.Library
{
    //<summary> Room model. </summary>
    public class Room

    {
        //<summary> Key. Used to uniquely identify this Room model. </summary>
        [Required]
        public Guid RoomId { get; set; }
        //<summary> Name of the training location where this room is
        //located.  Example: "Reston", "Tampa" or, "Dallas".
        //</summary>
        [Required]
        [StringLength(255)]
        public string Location { get; set; }
        //<summary> This Address model for this room. </summary>
        [Required]
        public Address Address { get; set; }
        //<summary> Number of unassigned beds in this room. </summary>
        [Required]
        public int Vacancy { get; set; }
        //<summary> Total number of beds in this room weather assigned or not</summary>
        [Required]
        public int Occupancy { get; set; }
        //<summary> Sex that this room accommodates. </summary>
        [Required]
        public string Gender { get; set; }

    }
}

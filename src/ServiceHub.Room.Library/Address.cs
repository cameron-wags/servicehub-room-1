using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceHub.Room.Library
{
    //<summary> Address Model Referenced by the Room model. </summary>
    public class Address

    {
        //<summary> Key. Used to uniquely identify this Address model. </summary>
        [Required]
        public Guid AddressId { get; set; }
        //<summary> Steet number and street name of this address. </summary>
        [Required]
        [StringLength(255)]
        public string Address1 { get; set; }
        //<summary> Apt/Room number for this address if applicable. </summary>
        public string Address2 { get; set; }
        //<summary> Name of the city for this address. </summary>
        [Required]
        [StringLength(25)]
        public string City { get; set; }
        //<summary> Name of the state for this address. </summary>
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }
        //<summary> 5 digit number specifing region. </summary>
        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string PostalCode { get; set; }
        //<summary> Name of the country for this address. </summary>
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Country { get; set; }

    }
}

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
        public Guid AddressId { get; set; }
        //<summary> Steet number and street name of this address. </summary>
        public string Address1 { get; set; }
        //<summary> Apt/Room number for this address if applicable. </summary>
        public string Address2 { get; set; }
        //<summary> Name of the city for this address. </summary>
        public string City { get; set; }
        //<summary> Name of the state for this address. </summary>
        public string State { get; set; }
        //<summary> 5 digit number specifing region. </summary>
        public string PostalCode { get; set; }
        //<summary> Name of the country for this address. </summary>
        public string Country { get; set; }

        public bool isValidState(Address model)
        {
            if (AddressId == System.Guid.Empty) { return false; }
            if (Address1 == null || Address1.Length > 255) { return false; }
            if (Address2 == null || Address2.Length > 255) { return false; }
            if (City == null || City.Length > 25) { return false; }
            if (State == null || State.Length > 2 || State.Length < 2) { return false; }
            if (PostalCode == null || PostalCode.Length > 5 || PostalCode.Length < 5) { return false; }
            if (Country == null || Country.Length > 3 || Country.Length < 3) { return false; }

            return true;

        }
    }
}

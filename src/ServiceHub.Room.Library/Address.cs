using System;
using System.Collections.Generic;
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
        //<summary> Second line of the address, if you've ever needed such a thing. </summary>
        public string Address2 { get; set; }
        //<summary> Name of the city for this address. </summary>
        public string City { get; set; }
        //<summary> Name of the state for this address. </summary>
        public string State { get; set; }
        //<summary> 5 to 9 digit number specifing region. </summary>
        public string PostalCode { get; set; }
        //<summary> Name of the country for this address. </summary>
        public string Country { get; set; }

    }
}

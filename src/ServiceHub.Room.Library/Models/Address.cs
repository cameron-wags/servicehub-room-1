﻿using System;
using System.Linq;
using System.Runtime.Serialization;

namespace ServiceHub.Room.Library.Models
{
    ///<summary> Address Model Referenced by the Room model. </summary>
    ///<remarks>This model is for the library and has validation.</remarks>
    [DataContract]
    public class Address {

        [IgnoreDataMember]
        private static readonly string[] StateCodes = {
            "AL", "AK", "AZ", "AR", "CA",
            "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA",
            "KS", "KY", "LA", "ME", "MD",
            "MA", "MI", "MN", "MS", "MO",
            "MT", "NE", "NV", "NH", "NJ",
            "NM", "NY", "NC", "ND", "OH",
            "OK", "OR", "PA", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT",
            "VA", "WA", "WV", "WI", "WY"
        };

        [IgnoreDataMember]
        private static readonly string[] CountryCodes = { "US" };

        ///<summary> Key. Used to uniquely identify this Address model. </summary>
        [DataMember]
        public Guid AddressId { get; set; }

        ///<summary> Steet number and street name of this address. </summary>
        [DataMember]
        public string Address1 { get; set; }

        ///<summary> Apt/Room number for this address if applicable. </summary>
        [DataMember]
        public string Address2 { get; set; }

        ///<summary> Name of the city for this address. </summary>
        [DataMember]
        public string City { get; set; }

        ///<summary> Name of the state for this address. </summary>
        [DataMember]
        public string State { get; set; }

        ///<summary> 5 digit number specifing region. </summary>
        [DataMember]
        public string PostalCode { get; set; }

        ///<summary> Name of the country for this address. </summary>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// Initialize an Address with invalid properties.
        /// </summary>
        public Address() {
            AddressId = Guid.Empty;
            Address1 = null;
            Address2 = null;
            City = null;
            State = null;
            PostalCode = null;
            Country = null;
        }

        /// <summary>
        /// Checks if state of model is valid
        /// </summary>
        /// <returns>True if the model is valid, false otherwise.</returns>
        public bool isValidState()
        {
            if (AddressId == Guid.Empty) { return false; }
            if (String.IsNullOrEmpty(Address1) || Address1?.Length > 255) { return false; }
            if (Address2?.Length > 255) { return false; }
            if (String.IsNullOrEmpty(City) || City?.Length > 25) { return false; }
            if (String.IsNullOrEmpty(State) || !StateCodes.Contains(State.ToUpper())) { return false; }
            if (String.IsNullOrEmpty(PostalCode) || PostalCode.Length != 5 || !PostalCode.All(Char.IsDigit)) { return false; }
            if (String.IsNullOrEmpty(Country) || !CountryCodes.Contains(Country.ToUpper())) { return false; }

            return true;
        }
    }
}

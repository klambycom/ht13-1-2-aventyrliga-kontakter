using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {
        class Contact_Metadata
        {
            [Required(ErrorMessage = "Epostaddress måste anges.")]
            [DisplayName("Epostaddress")]
            public string EmailAddress { get; set; }

            [Required(ErrorMessage = "Förnamn måste anges.")]
            [DisplayName("Förnamn")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Efternamn måste anges.")]
            [DisplayName("Efternamn")]
            public string LastName { get; set; }
        }
    }
}
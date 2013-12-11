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
            [Required]
            [EmailAddress]
            [StringLength(50)]
            [DisplayName("E-mail address")]
            public string EmailAddress { get; set; }

            [Required]
            [StringLength(50)]
            [DisplayName("First Name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(50)]
            [DisplayName("Last Name")]
            public string LastName { get; set; }
        }
    }
}
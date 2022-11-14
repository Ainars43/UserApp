using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models
{
    public partial class Persons
    {
        [Key]
        public string FirstName { get; set; }
        [Key]
        public string LastName { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Adress { get; set; }
        public string Action { get; set; }
    }
}

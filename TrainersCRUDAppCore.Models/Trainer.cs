using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainersCRUDAppCore.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName( "Last Name")]
        public string LastName { get; set; }

        [MaxLength(60)]
        public string Subject { get; set; }
    }
}

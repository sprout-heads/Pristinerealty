using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pristinerealty.Entity
{
   public class UserMessages
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}

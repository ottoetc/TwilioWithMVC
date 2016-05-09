using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwilioWithMVC.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int MessageId { get; set; }
        public virtual ICollection<ContactMessage> ContactMessages {get; set;}
        public virtual ApplicationUser User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TwilioWithMVC.Models
{
    [Table("ContactMessage")]
    public class ContactMessage
    {
        [Key]
        public int MessageId { get; set; }
        public Message Message { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}

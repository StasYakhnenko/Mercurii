using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DB
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        
        public int SenderId { get; set; }

        [ForeignKey("GetterId")]
        public User Getter { get; set; }

        public int GetterId { get; set; }

        public string Text { get; set; }
    }
}

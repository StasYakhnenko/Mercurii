using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DB
{
    public class Friendship
    {
        public int Id { get; set; }
        [ForeignKey("FirtstFriendId")]
        public User FirtstFriend { get; set; }

        public int FirtstFriendId { get; set; }

        [ForeignKey("SecondFriendId")]
        public User SecondFriend { get; set; }

        public int SecondFriendId { get; set; }

        public bool IsConfirmed { get; set; }
    }
}

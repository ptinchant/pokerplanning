using System;
using System.Collections.Generic;
using System.Text;

namespace PokerPlanning.Models.Model
{
    public class Room
    {
        public long RoomId { get; set; }
        public string RoomName { get; set; }
        public List<Member> Members { get; set; }

    }
}

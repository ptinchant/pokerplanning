using System;
using System.Collections.Generic;
using System.Text;

namespace PokerPlanning.Models.RequestModel
{
    public class MemberRequestModel
    {
        public long RoomId { get; set; }
        public long MemberId { get; set; }
        public string MemberName { get; set; }
    }
}

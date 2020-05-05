using System;
using System.Collections.Generic;
using System.Text;

namespace PokerPlanning.Models.ResponseModel
{
    public class RoomResponseModel
    {
        public long RoomId { get; set; }
        public string RoomName { get; set; }
        public List<MemberResponseModel> Members { get; set; }
    }
}

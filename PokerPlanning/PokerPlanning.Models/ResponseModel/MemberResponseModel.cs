namespace PokerPlanning.Models.ResponseModel
{
    public class MemberResponseModel
    {
        public RoomResponseModel Room { get; set; }
        public long MemberId { get; set; }
        public string MemberName { get; set; }
    }
}
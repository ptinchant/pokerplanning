using PokerPlanning.Models.Model;
using PokerPlanning.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerPlanning.Core.Interfaces
{
    public interface IRoomService
    {
        RoomResponseModel Create(Room room);
        IEnumerable<RoomResponseModel> List();
        RoomResponseModel GetRoom(long roomId);
    }
}

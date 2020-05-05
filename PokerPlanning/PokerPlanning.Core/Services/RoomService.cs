using PokerPlanning.Core.Interfaces;
using PokerPlanning.CrossCutting;
using PokerPlanning.Infrastructure.Interfaces;
using PokerPlanning.Models.Model;
using PokerPlanning.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerPlanning.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public RoomResponseModel Create(Room room)
        {
            throw new NotImplementedException();
        }

        public RoomResponseModel GetRoom(long roomId)
        {
            
            return new Profiler<Room, RoomResponseModel>().Convert(_roomRepository.GetRoom(roomId));
        }

        public IEnumerable<RoomResponseModel> List()
        {
            throw new NotImplementedException();
        }
    }
}

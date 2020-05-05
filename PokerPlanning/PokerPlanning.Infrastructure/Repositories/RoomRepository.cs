using PokerPlanning.Infrastructure.Context;
using PokerPlanning.Infrastructure.Interfaces;
using PokerPlanning.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerPlanning.Infrastructure.Repositories
{
    public class RoomRepository: IRoomRepository
    {
        private ApiContext _context;
        public RoomRepository(ApiContext context)
        {
            _context = context;
        }

        public Room GetRoom(long roomId)
        {
            return _context.Rooms.FirstOrDefault(f => f.RoomId == roomId);
        }
    }
}

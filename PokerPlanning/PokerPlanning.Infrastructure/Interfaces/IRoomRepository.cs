using PokerPlanning.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerPlanning.Infrastructure.Interfaces
{
    public interface IRoomRepository
    {
        Room GetRoom(long roomId);
    }
}

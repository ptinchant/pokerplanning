using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokerPlanning.Core.Interfaces;
using PokerPlanning.CrossCutting;
using PokerPlanning.Models.Model;
using PokerPlanning.Models.ResponseModel;

namespace PokerPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {

        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet("GetRoom/{roomId}")]
        public RoomResponseModel GetRoom(long roomId)
        {
            return _roomService.GetRoom(roomId);
        }
    }
}
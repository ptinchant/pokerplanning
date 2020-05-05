using Microsoft.EntityFrameworkCore;
using PokerPlanning.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerPlanning.Infrastructure.Context
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
          : base(options)
        { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}

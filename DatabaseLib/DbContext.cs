using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DatabaseLib
{
    public class BlackjackDBContext : DbContext
    {
        private const string connectString = @"server=(localdb)\MSSQLLocalDb;database=Blackjack;trusted_connection=true";

        public DbSet<GamePlayer> players { get; set; }
        //public DbSet<Game> game { get; set; }

        public BlackjackDBContext() : base()
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib
{
    /// <summary>
    /// Niclas Svensson
    /// 2017-10-11
    /// 
    /// DbWriter maintains the objects on the local database and uses LINQ to return and add values to it
    /// </summary>
    public class DbWriter
    {
        /// <summary>
        /// <para>Create a game with players and add to database</para>
        /// 
        /// <para>Make sure that players have a game ID connected to it!!</para>
        /// </summary>
        public void InitializeGame()
        {
            using(var db = new BlackjackDBContext())
            {
                GamePlayer gplayer = new GamePlayer();
                gplayer.Money = 1000;

                db.players.Add(gplayer);
                db.SaveChanges();

            }
        }
        /// <summary>
        /// Add a player to the database
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        public int AddPlayer(string playerName)
        {
            using (var db = new BlackjackDBContext())
            {
                GamePlayer gplayer = new GamePlayer();
                gplayer.Money = 1000;
                gplayer.Name = playerName;
                db.players.Add(gplayer);
                db.SaveChanges();

                return gplayer.ID;
            }
        }
        /// <summary>
        /// Update a player's money
        /// </summary>
        /// <param name="name"></param>
        /// <param name="money"></param>
        public void UpdatePlayerMoney(string name, int money)
        {
            using (var db = new BlackjackDBContext())
            {
                foreach (var oldPlayer in db.players.Where(w => w.Name.ToLower() == name.ToLower()))
                {
                    oldPlayer.Money = money;

                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Return a value if a player exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckPlayerExist(string name)
        {
            using (var db = new BlackjackDBContext())
            {
                var player = db.players.First(a => a.Name.ToLower() == name.ToLower());
                if(player != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Return a GamePlayer object exclusive for the database matching the name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GamePlayer ReturnPlayer(string name)
        {
            using (var db = new BlackjackDBContext())
            {
                var player = db.players.First(a => a.Name.ToLower() == name.ToLower());
                if (player != null)
                {
                    return player;
                }
                else
                {
                    return new GamePlayer();
                }
            }
        }
    }
}

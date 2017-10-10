using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib
{
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

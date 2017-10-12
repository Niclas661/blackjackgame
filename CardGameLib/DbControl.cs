using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLib;
using System.Diagnostics;

namespace CardGameLib
{
    /// <summary>
    /// Niclas Svensson
    /// 2017-10-11
    /// 
    /// DbControl is a class on the Game's side that can communicate with another interface on DatabaseLib
    /// </summary>
    public class DbControl
    {
        public DbControl()
        {

        }
        /// <summary>
        /// Add a player to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string AddPlayer(string name)
        {
            try
            {
                DbWriter writer = new DbWriter();
                writer.AddPlayer(name);
                return name;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
        /// <summary>
        /// Update a player's money
        /// </summary>
        /// <param name="player"></param>
        public void UpdatePlayer(Player player)
        {
            try
            {
                DbWriter writer = new DbWriter();
                writer.UpdatePlayerMoney(player.Name, player.Money);
            }
            catch
            {
                Debug.Write("Could not write");
                return;
            }
        }
        /// <summary>
        /// Return either true or false if a player with a chosen name exists in the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckPlayerExists(string name)
        {
            try
            {
                DbWriter writer = new DbWriter();
                var exists = writer.CheckPlayerExist(name);
                return exists;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Return a player from the database with that name
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Player GetPlayerByName(string text)
        {
            try
            {
                DbWriter writer = new DbWriter();
                var exists = writer.ReturnPlayer(text);
                if(exists.Name != null)
                {
                    return new Player()
                    {
                        Name = exists.Name,
                        Money = exists.Money
                    };
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Return a player's money
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int GetPlayerMoneyByName(string text)
        {
            try
            {
                DbWriter writer = new DbWriter();
                var exists = writer.ReturnPlayer(text);
                if (exists.Name != null)
                {
                    return exists.Money;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}

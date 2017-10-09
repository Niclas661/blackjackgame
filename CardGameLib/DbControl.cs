using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLib;

namespace CardGameLib
{
    public class DbControl
    {
        public DbControl()
        {

        }
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

        public int GetPlayerIdByName(string text)
        {
            throw new NotImplementedException();
        }

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

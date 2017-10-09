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
                var exists = writer.FindPlayer(name);
                return exists;
            }
            catch
            {
                return false;
            }
        }

        public string GetPlayerByName(string text)
        {
            throw new NotImplementedException();
        }

        public int GetPlayerIdByName(string text)
        {
            throw new NotImplementedException();
        }

        public int GetPlayerMoneyByName(string text)
        {
            throw new NotImplementedException();
        }
    }
}

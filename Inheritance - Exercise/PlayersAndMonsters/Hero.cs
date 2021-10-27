using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public Hero(string username,int level)
        {
            Username = username;
            Level = level;
        }
        public string Username { get; set; }
        public int Level { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Type: {GetType().Name} Username: {Username} Level: {Level}");

            return sb.ToString();
        }
    }
}

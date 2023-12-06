using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Player_and_Team_Requirements.player;

namespace Player_and_Team_Requirements
{
         internal interface ITeam
   
        {
            void Add(Player player);
            void Remove(int playerId);
            Player GetPlayerById(int playerId);
            Player GetPlayerByName(string playerName);
            List<Player> GetAllPlayers();
        }
    
}

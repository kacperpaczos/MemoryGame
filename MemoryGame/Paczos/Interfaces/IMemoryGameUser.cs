using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczos.Interfaces
{
    internal interface IMemoryGameUser
    {
        string GetFirstName();
        void SetFirstName(string firstName);
        string GetLastName();
        void SetLastName(string lastName);
        string GetNickname();
        void SetNickname(string nickname);
        string GetKeyData();
        void SetKeyData(string keyData);
        int GetPoints();
        void SetPoints(int points);
        int GetGamesPlayed();
        void SetGamesPlayed(int gamesPlayed);
        int GetId();
        void SetId(int id);
    }
}

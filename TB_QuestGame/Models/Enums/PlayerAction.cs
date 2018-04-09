using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum PlayerAction
    {
        None,
        MissionSetup,
        RandomName,
        LookAround,
        LookAt,
        PickUp,
        PutDown,
        Inventory,
        TreasureInventory,
        Travel,
        PlayerInfo,
        EditPlayerInfo,
        PirateLocationsVisited,
        ListDestinations,
        ListGameObjects,
        ListTreasures,
        AdminMenu,
        ReturnToMainMenu,  
        Return,
        Exit
    }
}

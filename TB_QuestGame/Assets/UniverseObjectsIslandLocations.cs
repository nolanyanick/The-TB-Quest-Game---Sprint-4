using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold all objects in the game universe; locations, game objects, npc's, etc.
    /// </summary>
    public static partial class UniverseObjects
    {
        /// <summary>
        /// list of island locations with properties
        /// </summary>
        public static List<IslandLocation> IslandLocations = new List<IslandLocation>()
        {
            //damp cell
            new IslandLocation
            {
                CommonName = "Damp Cell",
                IslandLocationID = 1,
                Date = 1252,
                Coordinates = "17.9368° N, 76.8411° W",
                Description = "You are currently in a small cell tucked away in a corner of one the larger rooms in the dungeon. " +
                    "Altought the smell is almost unbareable, you've made this small space your temporary home as plot your escape. " +
                    "The isolation provided by the cell allows to stay hidden from possible threats, and " +
                    "it allows you to work/plan in secrecy.",
                GeneralContents = "The cell is extremely cramped and movement is very limited." +
                    "There are numerous cobwebs that litter the walls and ceiling and the smell " +
                    "is so bad, rats don't even make their apparence here. In the far corner of the cell " +
                    "water is leaking through a crack in the ceiling and down to puddle on the floor, contributing " +
                    "to the horrible smell.",
                Accessible = true,
                ExperiencePoints = 0
            },

            //tortuga
            new IslandLocation
            {
                CommonName = "Dark Corridor",
                IslandLocationID = 2,
                Date = 1657,
                Coordinates = "20.0549° N, 72.7925° W",
                Description = "The island of Tortuga has been a hotbed of pirate/buccaneer activity ever " +
                    " since contol over the island split between the French, English, and the Spanish. " +
                    "Amongst the constant fighting over the years, a thriving community of pirates has " +
                    "been growing making Tortuga one of the most dangerous places in all of the Caribbean.",
                GeneralContents = "As you make your way through the swampy island of Tortuga, you notice  " +
                    "that this island consists of mostly pirates and renegades, you should do your best " +
                    "to avoid everyone, unless you're looking for a fight. \n",
                Accessible = true,
                ExperiencePoints = 10
            },

            //kingston
            new IslandLocation
            {
                CommonName = "Forgotten Vault",
                IslandLocationID = 3,
                Date = 1657,
                Coordinates = "44.2312° N, 76.4860° W",
                Description = "Kingston is a beautful town surrounded by the Blue Mountains, Red Hills, Long Mountains " +
                    "and the Kingston Harbour. Much like Port Royal, Kingston also resembles a tropical paradise.",
                GeneralContents = "Kingston is a semi-large town known for it's numerous markets where seemingly endless " +
                    "amounts of goods and servcies of all kinds are bought and sold. " +
                    "Becasue of this, Kingston is often filled with traders, travelers, pirates, etc. " +
                    "all here to experience the trading hotbed.",
                Accessible = false,
                ExperiencePoints = 10
            },

            //isla de la muerte
            new IslandLocation
            {
                CommonName = "Portal Room",
                IslandLocationID = 4,
                Date = 1657,
                Coordinates = "25.0343° N, 77.3963° W",
                Description = "Isla de la Muerte is an extremely dangerous place for anyone other than " +
                    "the most ruthless pirates to sail these seas. The island itself is by far the " +
                    "smallest piece of land in the Caribbean and is home to the " +
                    "largest volcano in the Caribbean. The entire island could easily be " +
                    "swallowed up by lava if an eruption were to occurr.",
                GeneralContents = "There are some small villages located throughout the island, " +
                    "but all abondoned or occupied by pirates and the waters surrounding the island " +
                    "are litered with pirate ships. It is said that the famed Blackbeard makes his home " +
                    "here; his ship, 'Queen Anne's Revenge', is often spotted sailing to and from Isla de la Muerte.",
                Accessible = false,
                ExperiencePoints = 10
            },

            //monarch bay
            new IslandLocation
            {
                CommonName = "Room of Silence",
                IslandLocationID = 5,
                Date = 1657,
                Coordinates = "18.2208° N, 66.5901°",
                Description = "Monarch Bay, located just south of Port Royal is an incredibly beautiful place." +
                    "Only a few large buildings, and some smaller homes, occupy the island. " +
                    "The structures are very lavish inside and out. The bay is also filled with tons of wild " +
                    "flowers, tropical plants/trees, crystal clear waters, and constant sunshine.",
                GeneralContents = "Monarch Bay acts as a resort for the affluent and wealthy, but at the expense of the locals. However," +
                    "because of that the bay is heavily guarded, provding protection for local villagers, but also a goldmine for pirates.",
                Accessible = false,
                ExperiencePoints = 10
            },

            //isle du soleil - modify
            new IslandLocation
            {
                CommonName = "Sacred Den",
                IslandLocationID = 6,
                Date = 1657,
                Coordinates = "18.1096° N, 77.2975° W",
                Description = "A remote island that recieves more sun than anywhere else in the Caribbean.\n" +
                "the island is laso litered with dangerous creatures, amongst the most ferocious are Sirens.",
                GeneralContents = " \n",
                Accessible = false,
                ExperiencePoints = 10
            },

            //renegade's beach - modify
            new IslandLocation
            {
                CommonName = "Cavern of Life",
                IslandLocationID = 7,
                Date = 1657,
                Coordinates = "18.1096° N, 77.2975° W",
                Description = "Renegade Beach is pirate trading hub. Known for it's prestine beaches and crystal clear waters " +
                "as well as the endless amounts of ruthless pirates looking to score on their latest plunder.\n",
                GeneralContents = "The beach is lined with pirate ships of all shapes and sizes. There are numerous market stalls " +
                "further within the main land trading unfathomable amounts of stolen goods. \n",
                Accessible = false,
                ExperiencePoints = 10
            },

            //shipwreck cove - modify
            new IslandLocation
            {
                CommonName = "Secret Armory",
                IslandLocationID = 8,
                Date = 1657,
                Coordinates = "9.1096° N, 64.2975° W",
                Description = " \n",
                GeneralContents = " \n",
                Accessible = false,
                ExperiencePoints = 10
            }
        };
    }
}
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
    public static class UniverseObjects
    {
        /// <summary>
        /// list of island locations with properties
        /// </summary>
        public static List<IslandLocation> IslandLocations = new List<IslandLocation>()
        {
            //port royal
            new IslandLocation
            {
                CommonName = "Port Royal",
                IslandLocationID = 0,
                Date = 1657,
                Coordinates = "17.9368° N, 76.8411° W",
                Description = "Located on the largest island in the Caribbean, Port Royal is the largest city " +
                    "functioning as the centre of shipping and commerce in the Caribbean Sea." +
                    "Currently under English control, Port Royal is not only a place of gaudy displays of" +
                    "wealth and loose morals, but also a mecha for pirates and buccaneers alike.",
                GeneralContents = "There are many ornate buildings lining the streets with numerous " +
                    "smaller shacks tucked away in the alleys. It's currently high noon making the port " +
                    "seem like a tropical paradise. There are countless people, " +
                    "ranging from English calvarymen to commonfolk and pirates, all  " +
                    "soaking up the sun and roaming the streets." +
                    " \n" +
                    " \n" +
                    " \n" +
                    "- stuff/NPC's located in town to be included -",
                Accessible = true,
                ExperiencePoints = 10
            },

            //tortuga
            new IslandLocation
            {
                CommonName = "Tortuga",
                IslandLocationID = 1,
                Date = 1657,
                Coordinates = "20.0549° N, 72.7925° W",
                Description = "The island of Tortuga has been a hotbed of pirate/buccaneer activity ever " +
                    " since contol over the island split between the French, English, and the Spanish. " +
                    "Amongst the constant fighting over the years, a thriving community of pirates has " +
                    "been growing making Tortuga one of the most dangerous places in all of the Caribbean.",
                GeneralContents = "As you make your way through the swampy island of Tortuga, you notice  " +
                    "that this island consists of mostly pirates and renegades, you should do your best " +
                    "to avoid everyone, unless you're looking for a fight." +
                    " \n" +
                    " \n" +
                    " \n" +
                    "- stuff/NPC's located in town to be included -",
                Accessible = true,
                ExperiencePoints = 10
            },

            //kingston
            new IslandLocation
            {
                CommonName = "Kingston",
                IslandLocationID = 2,
                Date = 386759,
                Coordinates = "44.2312° N, 76.4860° W",
                Description = "Kingston is a beautful town surrounded by the Blue Mountains, Red Hills, Long Mountains " +
                    "and the Kingston Harbour. Much like Port Royal, Kingston also resembles a tropical paradise.",
                GeneralContents = "Kingston is a semi-large town known for it's numerous markets where seemingly endless " +
                    "amounts of goods and servcies of all kinds are bought and sold. " +
                    "Becasue of this, Kingston is often filled with traders, travelers, pirates, etc. " +
                    "all here to experience the trading hotbed." +
                    " \n" +
                    " \n" +
                    " \n" +
                    "- stuff/NPC's located in town to be included -",
                Accessible = true,
                ExperiencePoints = 20
            },

            //isla de la muerte
            new IslandLocation
            {
                CommonName = "Isla de la Muerte",
                IslandLocationID = 3,
                Date = 386759,
                Coordinates = "25.0343° N, 77.3963° W",
                Description = "Isla de la Muerte is an extremely dangerous place for anyone other than " +
                    "the most ruthless pirates to sail these seas. The island itself is by far the " +
                    "smallest piece of land in the Caribbean and is home to the " +
                    "largest volcano in the Caribbean. The entire island could easily be " +
                    "swallowed up by lava if an eruption were to occurr.",
                GeneralContents = "There are some small villages located throughout the island, " +
                    "but all abondoned or occupied by pirates and the waters surrounding the island " +
                    "are litered with pirate ships. It is said that the famed Blackbeard makes his home " +
                    "here; his ship, 'Queen Anne's Revenge', is often spotted sailing to and from Isla de la Muerte." +
                    " \n" +
                    " \n" +
                    " \n" +
                    "- stuff/NPC's located in town to be included -",
                Accessible = false,
                ExperiencePoints = 10
            },

            //monarch bay
            new IslandLocation
            {
                CommonName = "Monarch Bay",
                IslandLocationID = 4,
                Date = 386759,
                Coordinates = "18.2208° N, 66.5901°",
                Description = "Monarch Bay, located just south of Port Royal is an incredibly beautiful place." +
                    "Only a few large buildings, and some smaller homes, occupy the island. " +
                    "The structures are very lavish inside and out. The bay is also filled with tons of wild " +
                    "flowers, tropical plants/trees, crystal clear waters, and constant sunshine.",                    
                GeneralContents = "Monarch Bay acts as a resort for the affluent and wealthy, but at the expense of the locals. However," +
                    "because of that the bay is heavily guarded, provding protection for local villagers, but also a goldmine for pirates.\n" +
                    " \n" +
                    " \n" +
                    " \n" +
                    "- stuff/NPC's located in town to be included -",
                Accessible = false,
                ExperiencePoints = 10
            },

            //isle du soleil - modify
            new IslandLocation
            {
                CommonName = "Île du Soleil",
                IslandLocationID = 5,
                Date = 386759,
                Coordinates = "18.1096° N, 77.2975° W",
                Description = "The Norlon Corporation research facility located in " +
                    "the city of Heraklion on the north coast of Crete and the top secret " +
                    "research lab for the Aion Project.\n",
                GeneralContents = "The lab is a large, well lit room, and staffed " +
                    "by a small number of scientists, all wearing light blue uniforms with the " +
                    "hydra-like Norlan Corporation logo. \n",
                Accessible = false,
                ExperiencePoints = 10
            },

            //renegade's beach - modify
            new IslandLocation
            {
                CommonName = "Renegade's Beach",
                IslandLocationID = 6,
                Date = 386759,
                Coordinates = "18.1096° N, 77.2975° W",
                Description = "The Norlon Corporation research facility located in " +
                    "the city of Heraklion on the north coast of Crete and the top secret " +
                    "research lab for the Aion Project.\n",
                GeneralContents = "The lab is a large, well lit room, and staffed " +
                    "by a small number of scientists, all wearing light blue uniforms with the " +
                    "hydra-like Norlan Corporation logo. \n",
                Accessible = false,
                ExperiencePoints = 10
            },

            //shipwreck cove - modify
            new IslandLocation
            {
                CommonName = "Shipwreck Cove",
                IslandLocationID = 7,
                Date = 386759,
                Coordinates = "9.1096° N, 64.2975° W",
                Description = "The Norlon Corporation research facility located in " +
                    "the city of Heraklion on the north coast of Crete and the top secret " +
                    "research lab for the Aion Project.\n",
                GeneralContents = "The lab is a large, well lit room, and staffed " +
                    "by a small number of scientists, all wearing light blue uniforms with the " +
                    "hydra-like Norlan Corporation logo. \n",
                Accessible = false,
                ExperiencePoints = 10
            }
        };
    }

}
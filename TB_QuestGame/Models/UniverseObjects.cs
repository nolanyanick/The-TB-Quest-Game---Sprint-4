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
        public static List<IslandLocation> IslandLocations = new List<IslandLocation>()
        {

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
                    "soaking up the sun and roaming the streets.",
                Accessible = true,
                ExperiencePoints = 10
            },

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
                "to avoid everyone, unless you're looking for a fight. The semi-large town" +
                "square is genrally a safe area on Tortuga, but still risky.",
                Accessible = true,
                ExperiencePoints = 10
            },

            new IslandLocation
            {
                CommonName = "Kingston",
                IslandLocationID = 2,
                Date = 386759,
                Coordinates = "44.2312° N, 76.4860° W",
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an " +
                              "open market managed by the Xantorian Commerce Coop. It is a place " +
                              "where many races from various systems trade goods.",
                GeneralContents = "- stuff in the room -",
                Accessible = false,
                ExperiencePoints = 20
            },

            new IslandLocation
            {
                CommonName = "Isla de la Muerte",
                IslandLocationID = 3,
                Date = 386759,
                Coordinates = "25.0343° N, 77.3963° W",
                Description = "The Norlon Corporation Headquarters is located in just outside of Detroit Michigan." +
                              "Norlon, founded in 1985 as a bio-tech company, is now a 36 billion dollar company " +
                              "with huge holdings in defense and space research and development.",
                GeneralContents = "- stuff in the room -",
                Accessible = false,
                ExperiencePoints = 10
            },
            new IslandLocation
            {
                CommonName = "Monarch Bay",
                IslandLocationID = 4,
                Date = 386759,
                Coordinates = "18.2208° N, 66.5901°",
                Description = "The Norlon Corporation research facility located in " +
                    "the city of Heraklion on the north coast of Crete and the top secret " +
                    "research lab for the Aion Project.\n",
                GeneralContents = "The lab is a large, well lit room, and staffed " +
                    "by a small number of scientists, all wearing light blue uniforms with the " +
                    "hydra-like Norlan Corporation logo. \n",
                Accessible = true,
                ExperiencePoints = 10
            },
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
            new IslandLocation
            {
                CommonName = "Renegade's Cove",
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
            }
        };
    }

}
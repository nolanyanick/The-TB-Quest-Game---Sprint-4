﻿using System;
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
                SpaceTimeLocationID = 1,
                UniversalDate = 1657,
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "Located on the largest island in the Caribbean, Port Royal is the largest city " +
                "functioning as the centre of shipping and commerce in the Caribbean Sea." +
                "Currently under English control, Port Royal is not only a place of gaudy displays of" +
                "wealth and loose morals, but also a mecha for pirates and buccaneers alike.",
                GeneralContents = "There are many ornate buildings lining the streets with numerous " +
                    "smaller shacks tucked aways in the alleys. It's currently high noon making the port" +
                    "seem like a tropical paradise. There are countless people, " +
                    "raning from English calvarymen to commonfolk and pirates, all  " +
                    "soaking up the sun and roaming the streets.",
                Accessable = true,
                ExperiencePoints = 10
            },

            new IslandLocation
            {
                CommonName = "Tortuga",
                SpaceTimeLocationID = 2,
                UniversalDate = 1657,
                UniversalLocation = "20.0549° N, 72.7925° W",
                Description = "The island of Tortuga has been a hotbed of pirate/buccaneer activity ever " +
                "contol over the island split between the French, English, and the Spanish. " +
                "Amongst the constant fighting over the years, a thriving community of pirates has " +
                "been growing making Tortuga one of the most dangeruous place in all of the Caribbean.",
                Accessable = true,
                ExperiencePoints = 10
            },

            new IslandLocation
            {
                CommonName = "Xantoria Market",
                SpaceTimeLocationID = 3,
                UniversalDate = 386759,
                UniversalLocation = "P-6, SS-3978, G-2976, LS-3976",
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an " +
                              "open market managed by the Xantorian Commerce Coop. It is a place " +
                              "where many races from various systems trade goods.",
                GeneralContents = "- stuff in the room -",
                Accessable = false,
                ExperiencePoints = 20
            },

            new IslandLocation
            {
                CommonName = "Norlon Corporate Headquarters",
                SpaceTimeLocationID = 4,
                UniversalDate = 386759,
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "The Norlon Corporation Headquarters is located in just outside of Detroit Michigan." +
                              "Norlon, founded in 1985 as a bio-tech company, is now a 36 billion dollar company " +
                              "with huge holdings in defense and space research and development.",
                GeneralContents = "- stuff in the room -",
                Accessable = true,
                ExperiencePoints = 10
            },
                        new IslandLocation
            {
                CommonName = "Aion Base Lab",
                SpaceTimeLocationID = 1,
                UniversalDate = 386759,
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "The Norlon Corporation research facility located in " +
                    "the city of Heraklion on the north coast of Crete and the top secret " +
                    "research lab for the Aion Project.\n",
                GeneralContents = "The lab is a large, well lit room, and staffed " +
                    "by a small number of scientists, all wearing light blue uniforms with the " +
                    "hydra-like Norlan Corporation logo. \n",
                Accessable = true,
                ExperiencePoints = 10
            },
        };
    }
}

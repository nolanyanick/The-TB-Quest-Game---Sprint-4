using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class UniverseObjects
    {
        public static List<Npc> Npcs = new List<Npc>()
        {
            new Civillian
            {
                Id = 1,
                Name = "Bernard Ebrhard",
                IslandLocationId = 1,
                Description = "A man dressed in fine clothing; seems like he comes from nobility.",
                Messages = new List<string>()
                {
                    "Oh, hello there. It's clear that you're not nobility...quite a shame indeed. " +
                    "My name is Bernard Ebrhard, heir to the Ebrhard fortune...at least I was.",

                    "If you're wondering why someone like me is here, keep guessing, you'll " +
                    "never find out.",

                    "Even though we may be in here together, that doesn't mean we're equals. Now buzz off! ",

                    "Ugh, this place is crawling with deviants and horrors of the worst kind. " +
                    "And you have got ot be the most annoying. Congratulations.",

                    "If I am to spend the rest of my days in this place, the last thing I want to do " +
                    "is spend my time talking to you.",

                    "Must you insist on continuing to annoy me!",

                    "Oh, I suppose you want to get out of here...well join the club. " +
                    "But if you promise to leave me alone for the rest of eternity, " +
                    "I can tell you what I know.",

                    "Seek out the dwarf by the name of Silas, the man's 342 years old and has been here as long as I can remember " +
                    "he's bound to have information on breaking out of this cesspit. However, allow " +
                    "me to give a formal warning; there is no exit. Once you're here, you're here for life.",

                    "Ah yes, my apologies. You can find Mr. Silas a few cell blocks from here in an area " +
                    "know as the 'Forgotten Vault', it's where he spends most of his time."
                }
            },

            new Civillian
            {
                Id = 2,
                Name = "Prisoner",
                IslandLocationId = 1,
                Description = "A man wearing dirty ragged clothes, who looks like he's been through alot.",
                Messages = new List<string>()
                {
                    "Nice to meet you, friend. Hopefully you wont be here too long.",
                    "I've been down here so long....can hardly remember who I am.",
                    "I was imprisoned long ago, not much else to say about me.",
                    "There's not really much to do down here, being a dungeon and all.",
                    "If you're looking for a way out, goodluck, I've searched everywhere."
                }
            },

            new Civillian
            {
                Id = 3,
                Name = "Silas",
                IslandLocationId = 2,
                Description = "A wise old dwarf with a long white beard.",
                Messages = new List<string>()
                {
                    "Hello stranger! My name is Silas.",

                    "Ahhh, so good ole Bernard sent ya? Well, I'd be more than happy to provide you with any assistance you need!",

                    "HA! You're looking for a way out, I should've guessed!",

                    "Well, there is a passage leading to a room of unknown origin...a room that holds doors leading " +
                    "to other worlds, at least according to the rumors. Now I have been to this perculiar room before " +
                    "and I can tell ya this, there are doors in there but noone nor do I have any idea as to where they lead." +
                    " \n" +
                    "I would suggest heading to that room, it's certainly a possibility that one of those doors is the way out. " +
                    "However getting there will cost your life.....unless you have this flawless diamond to gain access.",

                    "There is very deadly and dangerous troll who patrols the halls leading to the room. " +
                    "The troll wont hesitate to rip you to shreds, unless ofcourse you offer him a diamond for safe passage.",

                    "Now ofcourse I can help ya break outta here, kid....but I require a little payment of my own first....",

                    "Find me a beautiful shiny emerald for my collection and I'll see that you get what you need."
                },
            },

        };
    }
}

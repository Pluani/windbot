using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using System.Linq;

namespace WindBot.Game.AI.Decks
{
    [Deck("Ignister", "AI_Ignister")]
    class IgnisterExecutor : DefaultExecutor
    {
        public class CardId
        {
            //monsters
            public const int Parallelexceed = 71278040;
            public const int Ladydebug = 16188701;
            public const int Balancerlord = 8567955;
            public const int Pikari = 16020923;
            public const int Doyon = 88413677;
            public const int Bururu = 42429678;
            public const int Achichi = 15808381;

            //spells
            public const int Lightningstorm = 14532163;
            public const int Potofdesires = 35261759;
            public const int Foolishburialgoods = 35726888;
            public const int Cynetmining = 57160136;
            public const int Potofavarice = 67169062;
            public const int Terraforming = 73628505;
            public const int AIdlereborn = 22933016;
            public const int Calledbythegrave = 24224830;
            public const int IgnisterAIland = 59054773;

            //extra
            public const int Windpegasus = 98506199;
            public const int Lightdragon = 61399402;
            public const int Arrival = 11738489;
            public const int Darkfluid = 68934651;
            public const int Avramax = 21887175;
            public const int Zeroboros = 66403530;
            public const int Accesscodetalker = 86066372;
            public const int Transcodetalker = 46947713;
            public const int Darktemplar = 97383507;
            public const int Updatejammer = 88093706;
            public const int Splashmage = 59859086;
            public const int Cybersewicckid = 52698008;
            public const int Linkdisciple = 32995276;
            public const int Linguriboh = 24842059;
        }

        List<int> AIdleRebornList = new List<int>
        {
            
        };

        List<int> AvariceList = new List<int>
        {

        };

        public IgnisterExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //Activate
            AddExecutor(ExecutorType.Activate, CardId.Terraforming);
            AddExecutor(ExecutorType.Activate, CardId.Foolishburialgoods, BurialGoodsEff);
            AddExecutor(ExecutorType.Activate, CardId.IgnisterAIland, IgnisterAIlandeff);
            AddExecutor(ExecutorType.Activate, CardId.Potofdesires, DefaultPotOfDesires);
            AddExecutor(ExecutorType.Activate, CardId.Calledbythegrave, DefaultCalledByTheGrave);
            AddExecutor(ExecutorType.Activate, CardId.Potofavarice, AvariceEff);

            AddExecutor(ExecutorType.Activate, CardId.AIdlereborn, AIdleRebornEff);
            //Default
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
        }
        public override bool OnSelectHand()
        {
            return true;
        }
        public bool IgnisterAIlandeff()
        {
            return true;
        }
        private bool BurialGoodsEff()
        {
            if (Bot.HasInMonstersZone(CardId.Doyon))
            {
                AI.SelectCard(CardId.IgnisterAIland);
                return true;
            }
            return false;
        }
        private bool AvariceEff()
        {
            AI.SelectCard(AvariceList);
            return true;
        }
        private bool AIdleRebornEff()
        {
            AI.SelectCard(AIdleRebornList);
            return true;
        }
    }
}
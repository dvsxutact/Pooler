using Pooler.Domain.Enums;

namespace Pooler.Domain.Entities
{
    public class GameDetails
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public GameType gameType { get; set; }

        public int InningCount { get; set; }

        public int P1_Defensive { get; set; }

        public int P2_Defensive { get; set; }

        public int P1_BNR { get; set; }

        public int P2_BNR { get; set; }

        public int P1_WOS { get; set; }

        public int P2_WOS { get; set; }
    }
}

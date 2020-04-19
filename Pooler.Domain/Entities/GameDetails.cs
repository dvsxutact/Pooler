using Pooler.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pooler.Domain.Entities
{
    public class GameDetails
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        [Display(Name = "Game Type")]
        public GameType gameType { get; set; }

        [Display(Name = "Total Innings")]
        public int InningCount { get; set; }

        [Display(Name = "Defensive")]
        public int P1_Defensive { get; set; }

        [Display(Name = "Defensive")]
        public int P2_Defensive { get; set; }

        [Display(Name = "Break & Run")]
        public int P1_BNR { get; set; }

        [Display(Name = "Break & Run")]
        public int P2_BNR { get; set; }

        [Display(Name = "Win on Break")]
        public int P1_WOS { get; set; }

        [Display(Name = "Win on Break")]
        public int P2_WOS { get; set; }
    }
}

using Pooler.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pooler.Domain.Entities
{
    /// <summary>
    /// A pool game is a game of pool and has the following characstics.
    /// 
    /// 2 players
    /// a game type ( 8 ball, 9-ball, 10-ball, 1-pocket, bank-8-ball, bank-9-ball, etc.)
    /// a start time
    /// a end time
    /// number of innings (number of rounds, similar to baseball)
    /// breaking player
    /// </summary>
    public class PoolGame
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Breaking Player")]
        public Player PlayerOne { get; set; }

        [Required]
        [Display(Name = "Player Two")]
        public Player PlayerTwo { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy hh:MM tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Game Start Time")]
        public DateTime gameStart { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy hh:MM tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Game End Time")]
        public DateTime gameEnd { get; set; }

        public GameDetails gameDetails { get; set; }

        [Display(Name = "Winner")]
        public Player Winner { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using Pooler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pooler.Models
{
    public class CreatePoolGameModel
    {
        public PoolGame poolGame { get; set; }

        public List<Player> AllPlayers { get; set; }

        //public int SelectedPlayerId { get; set; }

        //public int SelectedPlayerOneId { get; set; }
                
        //public int SelectedPlayerTwoId { get; set; }
        
        public IEnumerable<SelectListItem> PlayerItems
        {
            get { if (AllPlayers != null)
                    return new SelectList(AllPlayers, "Id", "Name");
                else
                    return null;
            }
        }
    }
}

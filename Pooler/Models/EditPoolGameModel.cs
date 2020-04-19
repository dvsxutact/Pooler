using Microsoft.AspNetCore.Mvc.Rendering;
using Pooler.Domain.Entities;
using System.Collections.Generic;

namespace Pooler.Models
{
    public class EditPoolGameModel     
    {
        public List<Player> AllPlayers { get; set; }

        public PoolGame PoolGame { get; set; }

        public IEnumerable<SelectListItem> PlayerItems
        {
            get
            {
                if (AllPlayers != null)
                    return new SelectList(AllPlayers, "Id", "Name");
                else
                    return null;
            }
        }
    }
}

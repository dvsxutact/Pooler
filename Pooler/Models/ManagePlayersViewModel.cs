using Microsoft.AspNetCore.Mvc.Rendering;
using Pooler.Domain.Entities;
using System.Collections.Generic;

namespace Pooler.Models
{
    public class ManagePlayersViewModel
    {
        public List<Player> AllPlayers { get; set; }

        public int SelectedPlayerId { get; set; }

        public IEnumerable<SelectListItem> PlayerItems
        {
            get { return new SelectList(AllPlayers, "Id", "Name"); }
        }
    }
}

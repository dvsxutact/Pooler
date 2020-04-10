using System.ComponentModel.DataAnnotations;

namespace Pooler.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]        
        public string Name { get; set; }

        [StringLength(200)]
        public string Email { get; set; }
                
        public string AccountNumber { get; set; }

        public bool Active { get; set; }
    }
}

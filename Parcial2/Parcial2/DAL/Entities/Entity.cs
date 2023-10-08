using System.ComponentModel.DataAnnotations;

namespace Parcial2.DAL.Entities
{
    public class Entity
    {       

        [Required]
        public Guid Id { get; set; }
        
        public DateTime? CreatedDate { get; set; }
       
        public DateTime? ModifiedDate { get; set; }
    }
}

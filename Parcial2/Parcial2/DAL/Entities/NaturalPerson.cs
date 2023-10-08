using System.ComponentModel.DataAnnotations;

namespace Parcial2.DAL.Entities
{
    public class NaturalPerson : Entity
    {
        [Display(Name = "Ingrese el nombre completo")]        
        [Required(ErrorMessage = "¡El campo {0} es requerido!")]
        public string FullName { get; set; }

        [Display(Name = "Ingrese su email")]       
        [Required(ErrorMessage = "¡El campo {0} es requerido!")]
        public string Email { get; set; }

        [Display(Name = "Ingrese fecha de cumpleaños")]        
        [Required(ErrorMessage = "¡El campo {0} es requerido!")]
        public string BirthDate { get; set; }

        [Display(Name = "Ingrese su edad")]        
        [Required(ErrorMessage = "¡El campo {0} es requerido!")]
        public string Age { get; set; }



    }




}


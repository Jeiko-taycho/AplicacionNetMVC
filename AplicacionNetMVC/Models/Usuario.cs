using System.ComponentModel.DataAnnotations;

namespace AplicacionNetMVC.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }

        
        [Required(ErrorMessage = "El Telefono es requerido")]
        [Display(Name ="Teléfono")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "El Celular es requerido")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        public string Email { get; set; }


    }
}

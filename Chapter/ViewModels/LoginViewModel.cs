using System.ComponentModel.DataAnnotations;

namespace Chapter.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe E-mail valido")]
        public string? Email { get; set; }

        [Required (ErrorMessage = "Informe senha valida")]
        public string? Senha { get; set; }   
    }
}

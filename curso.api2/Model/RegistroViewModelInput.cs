using System.ComponentModel.DataAnnotations;

namespace curso.api2.Model
{
    public class RegistroViewModelInput
    {
        [Required(ErrorMessage = "O Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obriogatório")]
        public string Senha { get; set; }

    }
}

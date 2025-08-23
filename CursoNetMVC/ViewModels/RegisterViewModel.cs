using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CursoNetMVC.ViewModels
{
    public class RegisterViewModel: LoginViewModel
    {
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = "Las contraseñas no coinciden.")]
        [DisplayName("Confirmar contraseña")]
        public string ConfirmPassword { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace MudBlazorApp.Components.Pages.Pacientes
{
    public class PacienteInputModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage =" {0} obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        public string Documento { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        public DateTime DataNascimento { get; set; } = DateTime.Today;
    }
}

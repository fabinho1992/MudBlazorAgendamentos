using System.ComponentModel.DataAnnotations;

namespace MudBlazorApp.Components.Pages.Pacientes
{
    public class PacienteInputModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Documento { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataNascimento { get; set; } = DateTime.Today;
    }
}

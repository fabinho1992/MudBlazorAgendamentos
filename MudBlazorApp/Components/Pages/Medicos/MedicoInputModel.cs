using System.ComponentModel.DataAnnotations;

namespace MudBlazorApp.Components.Pages.Medicos
{
    public class MedicoInputModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Obrigatório")]
        public string Nome { get; set; } = null!;
        [Required(ErrorMessage = "{0} Obrigatório")]
        public string Celular { get; set; } = null!;
        [Required(ErrorMessage = "{0} Obrigatório")]
        public string Documento { get; set; } = null!;
        [Required(ErrorMessage = "{0} Obrigatório")]
        public string Crm { get; set; } = null!;
        [Required(ErrorMessage = "{0} Obrigatório")]
        public int EspecialidadeId { get; set; }
    }
}

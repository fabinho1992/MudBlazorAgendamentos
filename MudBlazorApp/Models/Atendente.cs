using Microsoft.AspNetCore.Identity;
using MudBlazorApp.Data;

namespace MudBlazorApp.Models
{
    public class Atendente : ApplicationUser
    {
        public string Nome { get; set; } = null!;
    }
}

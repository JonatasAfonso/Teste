using System.ComponentModel.DataAnnotations;

namespace Recrutamento.Web;

public sealed class CandidateInput
{
    [Required(ErrorMessage = "Informe o nome.")]
    [StringLength(100)]
    [Display(Name = "Nome")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Informe o e-mail.")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
    [StringLength(254)]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Informe a vaga de interesse.")]
    [StringLength(100)]
    [Display(Name = "Vaga de interesse")]
    public string Role { get; set; } = "";

    [Required(ErrorMessage = "Conte um pouco sobre a experiência.")]
    [StringLength(2000)]
    [Display(Name = "Experiência")]
    public string Experience { get; set; } = "";
}

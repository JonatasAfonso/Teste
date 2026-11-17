using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Recrutamento.Web.Pages;

public class IndexModel(CandidateStore store) : PageModel
{
    [BindProperty]
    public CandidateInput Candidate { get; set; } = new();

    public List<CandidateInput> Candidates { get; private set; } = [];

    [TempData]
    public string? Message { get; set; }

    public void OnGet() => Candidates = store.GetAll();

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            Candidates = store.GetAll();
            return Page();
        }

        store.Add(Candidate);
        Message = "Candidatura cadastrada com sucesso.";
        return RedirectToPage();
    }
}

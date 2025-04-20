using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBootstrapApp.Models;

namespace MyBootstrapApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ClassInformationModel NewClass { get; set; }

        public List<ClassInformationModel> ClassList => ClassDataStore.ClassList;

        public void OnGet()
        {
            // nothing special needed here
        }

        public IActionResult OnPostAdd()
        {
            if (!ModelState.IsValid)
                return Page();

            NewClass.Id = ClassDataStore.ClassList.Count + 1;
            ClassDataStore.ClassList.Add(NewClass);
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var item = ClassDataStore.ClassList.FirstOrDefault(x => x.Id == id);
            if (item != null)
                ClassDataStore.ClassList.Remove(item);

            return RedirectToPage();
        }
    }

    // Helper class to act like our fake database
    public static class ClassDataStore
    {
        public static List<ClassInformationModel> ClassList { get; } = new List<ClassInformationModel>();
    }
}

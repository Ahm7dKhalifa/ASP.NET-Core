using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstCoreApp.Models;

namespace MyFirstCoreApp.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly MyFirstCoreApp.Models.BloggingContext _context;

        public CreateModel(MyFirstCoreApp.Models.BloggingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BlogId"] = new SelectList(_context.Blog, "BlogId", "Url");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Post.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
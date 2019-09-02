using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFirstCoreApp.Models;

namespace MyFirstCoreApp.Pages.Blogs
{
    public class DetailsModel : PageModel
    {
        private readonly MyFirstCoreApp.Models.BloggingContext _context;

        public DetailsModel(MyFirstCoreApp.Models.BloggingContext context)
        {
            _context = context;
        }

        public Blog Blog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog = await _context.Blog.FirstOrDefaultAsync(m => m.BlogId == id);

            if (Blog == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly MyFirstCoreApp.Models.BloggingContext _context;

        public IndexModel(MyFirstCoreApp.Models.BloggingContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get;set; }

        public async Task OnGetAsync()
        {
            Blog = await _context.Blog.ToListAsync();
        }
    }
}

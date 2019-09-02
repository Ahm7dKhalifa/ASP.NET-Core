using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFirstCoreApp.Models;

namespace MyFirstCoreApp.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly MyFirstCoreApp.Models.BloggingContext _context;

        public IndexModel(MyFirstCoreApp.Models.BloggingContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Post
                .Include(p => p.Blog).ToListAsync();
        }
    }
}

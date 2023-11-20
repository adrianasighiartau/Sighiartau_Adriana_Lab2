using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sighiartau_Adriana_Lab2.Data;
using Sighiartau_Adriana_Lab2.Models;

namespace Sighiartau_Adriana_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Sighiartau_Adriana_Lab2.Data.Sighiartau_Adriana_Lab2Context _context;

        public IndexModel(Sighiartau_Adriana_Lab2.Data.Sighiartau_Adriana_Lab2Context context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }


        public IList<Book> BookData { get; set; } = default!;
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string
searchString)
        {
            if (_context.Book != null)
            {
                BookData = await _context.Book
                    .Include(b => b.Publisher)
                    .Include(b => b.Author)

                    .ToListAsync();
                TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
                AuthorSort = sortOrder == "author" ? "author_desc" : "author";

                CurrentFilter = searchString;

                if (!String.IsNullOrEmpty(searchString))
                {
                    BookData = (IList<Book>)BookData.Where(s => s.Author.FirstName.Contains(searchString)

                   || s.Author.LastName.Contains(searchString)
                   || s.Title.Contains(searchString));

                    switch (sortOrder)
                    {
                        case "title_desc":
                            BookData = BookData.OrderByDescending(s =>
                           s.Title).ToList();
                            break;
                        case "author_desc":
                            BookData = BookData.OrderByDescending(s =>
                           s.Author.FullName).ToList();
                            break;
                        case "author":
                            BookData = BookData.OrderBy(s =>
                           s.Author.FullName).ToList();
                            break;
                        default:
                            BookData = BookData.OrderBy(s => s.Title).ToList();
                            break;
                    }

                }
            }
        }
    }
}

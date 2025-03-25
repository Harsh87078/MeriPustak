using MeriPustakWebRazor_Temp.Data;
using MeriPustakWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeriPustakWebRazor_Temp.Categories
{
    public class IndexModel : PageModel
    {
        private readonly MeriPustakDbContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(MeriPustakDbContext db)
        {
            _db = db;
        }   
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}

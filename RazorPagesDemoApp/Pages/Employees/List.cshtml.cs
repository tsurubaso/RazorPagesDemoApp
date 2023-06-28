using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Data;

namespace RazorPagesDemoApp.Pages.Employees
{
    public class ListModel : PageModel
    {

        private readonly RazorPagesDemoDbContext dbcontext;

        public List<Models.Domain.Employee> Employees { get; set; }

        public ListModel(RazorPagesDemoDbContext dbcontext)
        {
            this.dbcontext = dbcontext;

        }



        public void OnGet()
        {
            Employees=dbcontext.Employees.ToList();
        }
    }
}

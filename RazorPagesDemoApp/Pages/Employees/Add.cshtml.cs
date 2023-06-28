using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Data;
using RazorPagesDemoApp.Models.Domain;
using RazorPagesDemoApp.Models.ViewModels;

namespace RazorPagesDemoApp.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbcontext;

        public AddModel(RazorPagesDemoDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
            
        }

        [BindProperty]

        public AddEmployeeViewModel AddEmployeeRequest  { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var employeDomainModel = new Employee
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary = AddEmployeeRequest.Salary,
                DateOfBirth = AddEmployeeRequest.DateOfBirth,
                Departement = AddEmployeeRequest.Departement

            };

            dbcontext.Employees.Add(employeDomainModel);
            dbcontext.SaveChanges();

            ViewData["Message"] = "Employee created successfully!";

        }    
    }
}

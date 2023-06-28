using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Data;
using RazorPagesDemoApp.Models.ViewModels;

namespace RazorPagesDemoApp.Pages.Employees
{
    public class EditModel : PageModel
    {


        private readonly RazorPagesDemoDbContext dbcontext;

        [BindProperty]
        public EditEmployeeViewModel EditEmployeeViewModel { get; set; }

        public EditModel(RazorPagesDemoDbContext dbcontext)
        {
            this.dbcontext = dbcontext;

        }









        public void OnGet(Guid id)
        {
            var employee = dbcontext.Employees.Find(id);
            if (employee != null)
            {
                EditEmployeeViewModel = new EditEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    DateOfBirth = employee.DateOfBirth,
                    Salary = employee.Salary,
                    Departement = employee.Departement

                };

            }

        }

        public void OnPost()
        {
            if (EditEmployeeViewModel != null)
            {
                var existingEmployee = dbcontext.Employees.Find(EditEmployeeViewModel.Id);
                if (existingEmployee != null)

                {


                    existingEmployee.Id = EditEmployeeViewModel.Id;
                    existingEmployee.Name = EditEmployeeViewModel.Name;
                    existingEmployee.Email = EditEmployeeViewModel.Email;
                    existingEmployee.Salary = EditEmployeeViewModel.Salary;
                    existingEmployee.DateOfBirth = EditEmployeeViewModel.DateOfBirth;
                    existingEmployee.Departement = EditEmployeeViewModel.Departement;

                    dbcontext.SaveChanges();


                }

            }



        }
    }
}

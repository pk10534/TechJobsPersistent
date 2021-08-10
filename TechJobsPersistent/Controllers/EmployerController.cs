using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        //DbContext Data
        private JobDbContext _context;

        public EmployerController(JobDbContext dbContext)
        {
            _context = dbContext;
        }
        //end dbcontext data


        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = _context.Employers.ToList(); //using tag method
            return View(employers);
        }



        public IActionResult Add()
        {
            AddEmployerViewModel employer = new AddEmployerViewModel();
            return View(employer); //tag method used
        }


        [HttpPost]
        public IActionResult Add (AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
           
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location

                };
                _context.Employers.Add(newEmployer);
                _context.SaveChanges();
                return Redirect("/Employer");
            }
            return View(addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            Employer employer = _context.Employers.Find(id);

            return View(employer);
        }



    }
}

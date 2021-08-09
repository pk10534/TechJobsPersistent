using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistent.Models;
using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.ViewModels
{


    public class AddJobViewModel
    {
        //jobName, employerId
        //List of all employers as sli

        [Required(ErrorMessage = "Employer Id is required!")]
        public int EmployerId { get; set; }

        public string Name { get; set; }

        public List<SelectListItem> Employers { get; set; }

        public AddJobViewModel(List<Employer> employers)
        {
            Employers = new List<SelectListItem>();
            foreach (var employer in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                }
                );
            }
        }

        public AddJobViewModel()
        {

        }




    }
}

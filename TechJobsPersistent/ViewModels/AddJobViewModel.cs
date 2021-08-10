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

        public List<Skill> Skills { get; set; }

        public AddJobViewModel()
        {

        }

        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {
            this.Skills = skills;
            this.Employers = new List<SelectListItem>();
            foreach (Employer employer in employers)
            {
                this.Employers.Add(
                    new SelectListItem
                    {
                        Value = employer.Id.ToString(),
                        Text = employer.Name
                    });
            }
        }






    }
}

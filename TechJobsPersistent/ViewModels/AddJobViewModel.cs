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

        public List<SelectListItem> Skills { get; set; }

        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {
            Skills = new List<SelectListItem>();
            Employers = new List<SelectListItem>();
            foreach (var employer in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                }
                );

                foreach (var skill in skills)
                    Skills.Add(new SelectListItem
                    {
                        Value = skill.Id.ToString(),
                        Text = skill.Name
                    });
            }
        }

        public AddJobViewModel()
        {

        }




    }
}

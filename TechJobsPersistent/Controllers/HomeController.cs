﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/AddJob")]
        public IActionResult AddJob()
        {
            List<Employer> employers = context.Employers.ToList();
            List<Skill> skills = context.Skills.ToList();
            AddJobViewModel job = new AddJobViewModel(employers, skills);
            return View(job);
        }

        [HttpPost]
        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = context.Employers.Find(addJobViewModel.EmployerId);
                Job newjob = new Job
                {
                    Name = addJobViewModel.Name,
                    Employer = newEmployer
                };
                foreach (var skill in selectedSkills)
                {
                    JobSkill newSkill = new JobSkill();
                    newSkill.SkillId = Int32.Parse(skill);
                    context.JobSkills.Add(newSkill);
                    /*
                    Skill newSkill = context.Skills.Find(selectedSkills);
                    context.Skills.Add(newSkill);
                    */
                }
                context.Jobs.Add(newjob);
                context.SaveChanges();
                return Redirect("/Home");
            }
            return View(addJobViewModel);
        }



        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}

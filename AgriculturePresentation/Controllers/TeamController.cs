using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace AgriculturePresentation.Controllers
{
    public class TeamController : AdminBaseController
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values = _teamService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(TeamAddViewModel model)
        {
            TeamValidator validationRules = new TeamValidator();

            Team team = new Team()
            {
                PersonName = model.Name,
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                FacebookUrl = model.FacebookUrl,
                InstagramUrl = model.InstagramUrl,
                WebsiteUrl = model.WebsiteUrl,
                TwitterUrl = model.TwitterUrl
            };

            ValidationResult result = validationRules.Validate(team);

            if (result.IsValid)
            {
                _teamService.Insert(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        [HttpPost]
        public IActionResult DeleteTeam(int id)
        {
            var value = _teamService.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            _teamService.Delete(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var value = _teamService.GetById(id);

            if (value == null)
            {
                return NotFound();
            }

            TeamEditViewModel model = new TeamEditViewModel()
            {
                TeamID = value.TeamID,
                Name = value.PersonName,
                Title = value.Title,
                ImageUrl = value.ImageUrl
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult EditTeam(TeamEditViewModel model)
        {
            var existingTeam = _teamService.GetById(model.TeamID);

            if (existingTeam == null)
            {
                return NotFound();
            }

            existingTeam.PersonName = model.Name;
            existingTeam.Title = model.Title;
            existingTeam.ImageUrl = model.ImageUrl;
            existingTeam.FacebookUrl = model.FacebookUrl;
            existingTeam.InstagramUrl = model.InstagramUrl;
            existingTeam.WebsiteUrl = model.WebsiteUrl;
            existingTeam.TwitterUrl = model.TwitterUrl;

            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(existingTeam);

            if (result.IsValid)
            {
                _teamService.Update(existingTeam);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(model);
        }
    }
}

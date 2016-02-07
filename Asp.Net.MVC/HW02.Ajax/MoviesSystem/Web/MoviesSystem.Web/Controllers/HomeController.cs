using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MoviesSystem.Models;
using MoviesSystem.Services.Contracts;
using MoviesSystem.Web.ViewModels;

namespace MoviesSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesService movies;

        public HomeController(IMoviesService movies)
        {
            this.movies = movies;
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            var toSkip = 0;
            var toTake = 5;

            if (page != null)
            {
                toSkip = int.Parse(page.ToString());
            }

            var moviesInDb = this.movies
                .GetAll(toSkip, toTake)
                .Project()
                .To<MovieViewModel>()
                .ToList();

            this.ViewBag.Pages = this.movies.GetCount() / toTake;
            this.ViewBag.CurrentPage = toSkip;

            return View(moviesInDb);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new MovieViewModel
            {
                LeadingMaleRole = new ActorViewModel()
                {
                    Genders = GetGenders(0)
                },
                LeadingFemaleRole = new ActorViewModel()
                {
                    Genders = GetGenders(1)
                }
            };

            return this.PartialView("_AddMovie", model);
        }

        [HttpPost]
        public ActionResult Add(MovieViewModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            if (ModelState.IsValid)
            {
                var newMovie = this.GetNewMovie(model);
                this.movies.Add(newMovie);

                return this.Content(string.Empty);
            }

            model.LeadingMaleRole.Genders = GetGenders(model.LeadingMaleRole.GenderId);
            model.LeadingFemaleRole.Genders = GetGenders(model.LeadingFemaleRole.GenderId);

            return this.PartialView("_AddMovie", model);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            var movie = this.movies.GetById(id);

            if (movie == null)
            {
                return this.RedirectToAction("Index");
            }

            var movieViewModel = Mapper.Map<MovieViewModel>(movie);

            movieViewModel.LeadingMaleRole.Genders = GetGenders(movieViewModel.LeadingMaleRole.GenderId);
            movieViewModel.LeadingFemaleRole.Genders = GetGenders(movieViewModel.LeadingFemaleRole.GenderId);

            return this.PartialView("_EditMovie", movieViewModel);
        }

        [HttpPost]
        public ActionResult Update(MovieViewModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            if (this.ModelState.IsValid)
            {
                var modelForUpdate = this.movies.GetById(model.Id);
                var updatedModel = UpdateModel(modelForUpdate, model);
                this.movies.Update(updatedModel);

                return this.PartialView("_ItemMovie", model);
            }

            model.LeadingMaleRole.Genders = GetGenders(model.LeadingMaleRole.GenderId);
            model.LeadingFemaleRole.Genders = GetGenders(model.LeadingFemaleRole.GenderId);

            return this.PartialView("_EditMovie", model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (this.movies.Any(id))
            {
                this.movies.DeleteById(id);
            }

            return this.RedirectToAction("Index");
        }

        public ActionResult Cancel(int id)
        {
            var movie = this.movies.GetById(id);

            if (movie == null)
            {
                return this.RedirectToAction("Index");
            }

            var moviewAsVm = Mapper.Map<MovieViewModel>(movie);

            return this.PartialView("_ItemMovie", moviewAsVm);
        }

        private List<SelectListItem> GetGenders(int id)
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Select Gender",
                    Value = "0"
                },
                new SelectListItem()
                {
                    Text = "Male",
                    Value = "0",
                    Selected = id.ToString() == "0"

                },
                new SelectListItem()
                {
                    Text = "Female",
                    Value = "1",
                    Selected = id.ToString() == "1"
                }
            };
        }

        private Movie UpdateModel(Movie modelForUpdate, MovieViewModel model)
        {
            modelForUpdate.Title = model.Title;
            modelForUpdate.Director = model.Director;
            modelForUpdate.Year = model.Year;

            modelForUpdate.LeadingMaleRole.Age = model.LeadingMaleRole.Age;
            modelForUpdate.LeadingMaleRole.Gender = model.LeadingMaleRole.GenderId == 0 ? GenderType.Male : GenderType.Female;
            modelForUpdate.LeadingMaleRole.Name = model.LeadingMaleRole.Name;
            modelForUpdate.LeadingMaleRole.Studio.Name = model.LeadingMaleRole.StudioName;
            modelForUpdate.LeadingMaleRole.Studio.Address = model.LeadingMaleRole.StudioAddress;

            modelForUpdate.LeadingFemaleRole.Age = model.LeadingFemaleRole.Age;
            modelForUpdate.LeadingFemaleRole.Gender = model.LeadingFemaleRole.GenderId == 0 ? GenderType.Male : GenderType.Female;
            modelForUpdate.LeadingFemaleRole.Name = model.LeadingFemaleRole.Name;
            modelForUpdate.LeadingFemaleRole.Studio.Name = model.LeadingFemaleRole.StudioName;
            modelForUpdate.LeadingFemaleRole.Studio.Address = model.LeadingFemaleRole.StudioAddress;

            return modelForUpdate;
        }

        private Movie GetNewMovie(MovieViewModel model)
        {
            var movie = new Movie
            {
                Title = model.Title,
                Director = model.Director,
                Year = model.Year
            };

            var maleRoleId = -1;
            var femaleRoleId = -1;

            if (this.movies.MaleRoleExist(model.LeadingMaleRole.Name, model.LeadingMaleRole.Age))
            {
                maleRoleId = this.movies.GetMaleRoleId(model.LeadingMaleRole.Name, model.LeadingMaleRole.Age);
            }

            if (this.movies.FemaleRoleExist(model.LeadingFemaleRole.Name, model.LeadingFemaleRole.Age))
            {
                femaleRoleId = this.movies.GetFemaleRoleId(model.LeadingFemaleRole.Name, model.LeadingFemaleRole.Age);
            }

            if (maleRoleId != -1)
            {
                movie.LeadingMaleRoleId = maleRoleId;
            }
            else
            {
                movie.LeadingMaleRole = new Actor()
                {
                    Age = model.LeadingMaleRole.Age,
                    Gender = GenderType.Male,
                    Name = model.LeadingMaleRole.Name,
                    Studio = new Studio()
                    {
                        Name = model.LeadingMaleRole.StudioName,
                        Address = model.LeadingMaleRole.StudioAddress
                    }
                };
            }

            if (femaleRoleId != -1)
            {
                movie.LeadingFemaleRoleId = femaleRoleId;
            }
            else
            {
                movie.LeadingFemaleRole = new Actor()
                {
                    Age = model.LeadingFemaleRole.Age,
                    Gender = GenderType.Female,
                    Name = model.LeadingFemaleRole.Name,
                    Studio = new Studio()
                    {
                        Name = model.LeadingFemaleRole.StudioName,
                        Address = model.LeadingFemaleRole.StudioAddress
                    }
                };
            }

            return movie;
        }
    }
}
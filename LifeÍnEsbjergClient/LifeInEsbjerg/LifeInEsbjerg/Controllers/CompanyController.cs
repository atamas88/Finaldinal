﻿using DtoModel;
using LifeInEsbjerg.Models.ViewModel;
using LifeInEsbjergGateway;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LifeInEsbjerg.Controllers
{
    
    public class CompanyController : Controller
    {
        private Facade facade = new Facade();
        
        // GET: Company
        public ActionResult Index(string searchString, int? id)
        {
            IEnumerable<Company> companies = facade.GetCompanyGateway().ReadAll();
            IEnumerable<Category> categories = facade.GetCategoryGateway().ReadAll();
            IEnumerable<Company> companies1 = facade.GetCompanyGateway().ReadAll();
            IList<Company> companies2 = new List<Company>();
            if (!String.IsNullOrEmpty(searchString))
            {
                //companies = companies.Where(s => s.Name.Contains(searchString));
                for(int i = 0; i < companies1.Count(); ++i)
                {
                    bool containstag = false;
                    bool containsname = false;
                    for (int j = 0; j < companies1.ElementAt(i).Tags.Count(); ++j)
                    {
                        if(companies1.ElementAt(i).Tags.ElementAt(j).Name.Contains(searchString))
                        {
                            containstag = true;
                        }
                    }
                    if(companies1.ElementAt(i).Name.Contains(searchString))
                    {
                        containsname = true;
                    }
                    if(containstag || containsname)
                    {
                        companies2.Add(companies1.ElementAt(i));
                    }
                }
                companies = companies2;
            }
            if (id == 1)
            {
                id = null;
            }
            if (id > 1)
            {
                for(int i = 0; i < companies.Count(); ++i)
                {
                    companies = companies.Where(s => s.Category.Id.Equals(id));
                }
            }

            companies = companies.OrderByDescending(c => c.overall);
            return View(companies);

        }

  

        public ActionResult GetNewestCompanies()
        {
            IEnumerable<Company> companies = facade.GetCompanyGateway().ReadAll();
            companies = companies.OrderByDescending(c => c.NrRate).Take(6);
            return PartialView(companies);
        }


        public ActionResult ListOfCat()
        {
            IEnumerable<Category> categories = facade.GetCategoryGateway().ReadAll();
            return PartialView(categories);
        }

        public ActionResult ListOfTags()
        {
            IEnumerable<Tag> tags = facade.GetTagGateway().ReadAll();
            return PartialView(tags);
        }
        public ActionResult Create(string userName)
        {
            var model = new LifeInEsbjergViewModel() { Category = new SelectList(facade.GetCategoryGateway().ReadAll(), "Id", "Name"),
                                                        Tags = new MultiSelectList(facade.GetTagGateway().ReadAll(), "Id", "Name"),
                                                        userName = userName};
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(LifeInEsbjergViewModel model)
        {
                List<Category> allCat = new List<Category>(facade.GetCategoryGateway().ReadAll());
                for(int i = 0; i < allCat.Count; ++i)
                {
                    if(allCat.ElementAt(i).Id == model.selectedCat)
                    {
                        model.Company.Category = allCat.ElementAt(i);
                    }
                }

            if (model.selectedTags != null)
            {
                var newList = new List<Tag>();
                List<Tag> allTag = new List<Tag>(facade.GetTagGateway().ReadAll());
                for(int i = 0; i < allTag.Count(); ++i)
                {
                    for (int j = 0; j < model.selectedTags.Count(); ++j)
                    {
                        if (allTag.ElementAt(i).Id == model.selectedTags.ElementAt(j))
                            newList.Add(new Tag() { Id = model.selectedTags.ElementAt(j) , Name = allTag.ElementAt(i).Name});
                    }
                }

                //foreach (int id in model.selectedTags)
                //{
                //    newList.Add(new Tag() { Id = id });
                //}
                model.Company.Tags = newList;
            }
            model.Company.Ratings = new List<Rating>();
            model.Company.Reviews = new List<Review>();
            model.Company.Badges = new List<Badge>();
            model.Company.NrRate = 0;
            model.Company.userName = model.userName;

            facade.GetCompanyGateway().Add(model.Company);
            
            return RedirectToAction("Login", "Account");
        }

       

        public ActionResult Delete(int? id)
        {
            Company company = facade.GetCompanyGateway().Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            facade.GetCompanyGateway().Delete(company);
            return RedirectToAction("Index", "Company");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = facade.GetCompanyGateway().Find(id);

            int selectedCat = company.Category.Id;

            var selectedTags = new List<int>();
            foreach (var item in company.Tags)
            {
                selectedTags.Add(item.Id);
            }

            var model = new LifeInEsbjergViewModel()
            {
                Company = company,
                Category = new SelectList(facade.GetCategoryGateway().ReadAll(), "Id", "Name"),
                selectedCat = selectedCat,
                Tags = new MultiSelectList(facade.GetTagGateway().ReadAll(), "Id", "Name"),
                selectedTags = selectedTags,
                nrRate = company.NrRate
                
                
            };

            model.ratings = new List<Rating>();

            foreach (var item in company.Ratings)
            {
                model.ratings.Add(item);
            }

            if (company == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Company, Category, selectedCat, Tags, selectedTags, ratings, nrRate")] LifeInEsbjergViewModel model)
        {

            //ViewBag.Genres = new SelectList(db.Genres, "Id", "Name");


            List<Category> allCat = new List<Category>(facade.GetCategoryGateway().ReadAll());
            for (int i = 0; i < allCat.Count; ++i)
            {
                if (allCat.ElementAt(i).Id == model.selectedCat)
                {
                    model.Company.Category = allCat.ElementAt(i);
                }
            }
            if (model.selectedTags != null)
            {
                var newList = new List<Tag>();
                List<Tag> allTag = new List<Tag>(facade.GetTagGateway().ReadAll());
                for (int i = 0; i < allTag.Count(); ++i)
                {
                    for (int j = 0; j < model.selectedTags.Count(); ++j)
                    {
                        if (allTag.ElementAt(i).Id == model.selectedTags.ElementAt(j))
                            newList.Add(new Tag() { Id = model.selectedTags.ElementAt(j), Name = allTag.ElementAt(i).Name });
                    }
                }

                //foreach (int id in model.selectedTags)
                //{
                //    newList.Add(new Tag() { Id = id });
                //}
                model.Company.Tags = newList;

                model.Company.NrRate = model.nrRate;
                model.Company.Ratings = model.ratings;
            }
            if (ModelState.IsValid)
            {

                facade.GetCompanyGateway().Update(model.Company);
                return RedirectToAction("Index");
            }
            //facade.GetMovieRepository().Edit(movie);
            return View(model.Company);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = facade.GetCompanyGateway().Find(id);
            //var selectGenres = new List<int>();
            //foreach (var item in movie.Genres)
            //{
            //    selectGenres.Add(item.Id);
            //}
            //var model = new CreateMovieViewModel()
            //{
            //    Movie = movie,
            //    Genres = new MultiSelectList(facade.GetGenreGateway().ReadAll(), "Id", "Name"),
            //    SelectedGenres = selectGenres
            //};

            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }
        [HttpGet]
        public ActionResult AddRating(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = facade.GetCompanyGateway().Find(id);
            var model = new RatingViewModel() { company = company };
            return View(model);
        }
        [HttpPost]
        public ActionResult AddRating(RatingViewModel model)
        {
            Rating rating = new Rating()
            {
                Quality = model.rating.Quality,
                CustomerService = model.rating.CustomerService,
                Price = model.rating.Price,
                OverAll = model.rating.OverAll
            };

            int id = Convert.ToInt32(model.company.Id);
            Company company = facade.GetCompanyGateway().Find(id);

            List<Rating> ratings = company.Ratings.ToList();

            ratings.Add(rating);

            company.Ratings = ratings;

            facade.GetRatingGateway().Add(rating);

            //if (model.company.NrRate >= 2)
            //{
                if (company.avgCust > 80)
                {
                    company = AddBadge(company, 1);
                }
                if (company.avgQua > 80)
                {
                     company = AddBadge(company, 2);
                }
                if (company.avgPrice > 80)
                {
                     company = AddBadge(company, 3);
                }
                if (company.overall > 80)
                {
                     company = AddBadge(company, 4);
                }
            if (company.avgCust < 80)
            {
                company = RemoveBadge(company, 1);
            }
            if (company.avgQua < 80)
            {
                company = RemoveBadge(company, 2);
            }
            if (company.avgPrice < 80)
            {
                company = RemoveBadge(company, 3);
            }
            if (company.overall < 80)
            {
                company = RemoveBadge(company, 4);
            }

            //}

            facade.GetCompanyGateway().Update(company);

            

            return RedirectToAction(actionName: "Details", controllerName:"Company", routeValues: new { Id = id});
        }

        public Company AddBadge(Company company, int badgeId)
        {
     
            bool already = false;
            for (int i = 0; i < company.Badges.Count(); ++i)
            {
                if (company.Badges.ElementAt(i).Id == badgeId)
                {
                    already = true;
                }
            }
            
            if (!already)
            {
                Badge badge = facade.GetBadgeGateway().Find(badgeId);
                List<Badge> badges = company.Badges.ToList();

                badges.Add(badge);

                company.Badges = badges;
            }

            return company;

        }

        public Company RemoveBadge(Company company, int badgeId)
        {
            bool contains = false;
            for(int i = 0; i < company.Badges.Count(); ++i)
            {
                if(company.Badges.ElementAt(i).Id == badgeId)
                {
                    contains = true;
                }
            }
            if (contains)
            {
                //Badge badge = facade.GetBadgeGateway().Find(badgeId);
                List<Badge> badges = company.Badges.ToList();

               
                badges.Remove(badges.FirstOrDefault(x => x.Id == badgeId));
                company.Badges = badges;
            }


            return company;
        }

        [HttpGet]
        public ActionResult AddReview(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = facade.GetCompanyGateway().Find(id);
            var model = new ReviewViewModel() { company = company };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddReview(ReviewViewModel model)
        {
            Review review = new Review()
            {
                Title = model.review.Title,
                Text = model.review.Text
            };

            int id = Convert.ToInt32(model.company.Id);
            Company company = facade.GetCompanyGateway().Find(id);

            List<Review> reviews = company.Reviews.ToList();

            reviews.Add(review);

            company.Reviews = reviews;

            facade.GetReviewGateway().Add(review);


            facade.GetCompanyGateway().Update(company);

            return RedirectToAction(actionName: "Details", controllerName: "Company", routeValues: new { Id = id });
        }

    }
}
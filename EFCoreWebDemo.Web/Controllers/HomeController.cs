using EFCoreWebDemo.Data;
using EFCoreWebDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace EFCoreWebDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connectionString;

        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");    
        }

        public IActionResult Index()
        {
            var repo = new PeopleRepository(_connectionString);
            var vm = new IndexViewModel
            {
                People = repo.GetAll()
            };
            return View(vm);
        }

        public IActionResult Edit(int personId)
        {
            var repo = new PeopleRepository(_connectionString);
            return View(new EditPersonViewModel
            {
                Person = repo.GetById(personId)
            });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            var repo = new PeopleRepository(_connectionString);
            repo.Add(person);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Update(Person person)
        {
            var repo = new PeopleRepository(_connectionString);
            repo.Update(person);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var repo = new PeopleRepository(_connectionString);
            repo.Delete(id);
            return RedirectToAction("index");
        }
    }
}

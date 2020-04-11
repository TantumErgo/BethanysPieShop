using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPieReviewRepository _pieReviewRepository;
        private readonly HtmlEncoder _htmlEncoder;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository,
            IPieReviewRepository pieReviewRepository, HtmlEncoder htmlEncoder)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            _pieReviewRepository = pieReviewRepository;
            _htmlEncoder = htmlEncoder;
        }

        //public ViewResult List()
        //{
        //    PiesListViewModel piesListViewModel = new PiesListViewModel();
        //    piesListViewModel.Pies = _pieRepository.AllPies;

        //    piesListViewModel.CurrentCategory = "Cheese cakes";
        //    return View(piesListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound(); 
            return View(new PieDetailViewModel() { Pie = pie });
        }

        [HttpPost]
        public IActionResult Details(int id, string review)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            string encodedReview = _htmlEncoder.Encode(review);
            _pieReviewRepository.AddPieReview(new PieReview() { Pie = pie, Review = encodedReview });

            return View(new PieDetailViewModel() { Pie = pie });
        }
    }
}

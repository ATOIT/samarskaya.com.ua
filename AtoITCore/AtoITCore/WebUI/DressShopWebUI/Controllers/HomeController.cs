using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Abstrac;
using Domain.Entityes;
using DressShopWebUI.Models;


namespace DressShopWebUI.Controllers
{

   
    public class HomeController : Controller
    {
        private readonly IReviewsRepository _reviewsRepository;
        private readonly IProductRepository _productRepository;
        
        public HomeController(IProductRepository productRepository,  IReviewsRepository reviewsRepo)
        {
            _productRepository = productRepository;
            _reviewsRepository = reviewsRepo;
        }

       
        public ViewResult Index()
        {
            return View();
        }

       
        public ActionResult Slider()  
        {
            return PartialView(_productRepository.Products.ToList());
        }

        
        public ActionResult Selling()
        {
            return View(_productRepository.Products.
                Where(x => x.Category == "Selling").
                OrderByDescending(x => x.DateCreate));
        }

     
        public ActionResult Gallery() 
        {
            return View(_productRepository.Products.
                Where(x => x.Category == "Gallery").
                OrderByDescending(x => x.DateCreate));
        }
        
        public ActionResult Partners() 
        {
            return View(_productRepository.Products.
                Where(x => x.Category == "Partners").
                OrderByDescending(x => x.DateCreate));
        }

        #region Отзывы

        public ViewResult ClientFeedback(int page = 1) 
        {
            int pageSize = 5;
            List<Reviews> rew = _reviewsRepository.Reviewses.OrderByDescending(x => x.DateFeedback).ToList();
            rew = rew.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = _reviewsRepository.Reviewses.Count() };
            PageModel ivm = new PageModel { PageInfo = pageInfo, Reviewses = rew };
            return View(ivm);
        }

        [HttpPost]
        public ActionResult Feedback(Reviews model) 
        {
            if (ModelState.IsValid)
            {
                _reviewsRepository.SaveReview(model);
                TempData["messageOk"] = "Благодарим Вас за отзыв!";
                return Redirect("/Home/ClientFeedback");
            }
            TempData["message"] = "Отзыв не был добавлен - проверьте правильность заполнения формы отзыва!";
            return Redirect("/Home/ClientFeedback");
        }
        #endregion

    }
}
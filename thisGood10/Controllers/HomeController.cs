using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thisGood10.Models;
using thisGood10.Models.ViewModels;



namespace thisGood10.Controllers
{
    public class HomeController : Controller
    {

        public int PageSize = 1;
        private DataManager dataManager;
        public HomeController(DataManager _dataManager)
        {
            dataManager = _dataManager;
        }


        public IActionResult Index()
        {

            return View();

        }
        public IActionResult sketchesProducts(string categoryName, int sketchPage = 1 )
        {
           

            return View( new SketchesListViewModel
            {

                Sketches = dataManager.sketchRepository.AllSketches()
                            .Where(p =>p.categoryName == null  || p.categoryName == categoryName)
                            .Skip((sketchPage - 1) * PageSize)
                            .Take(PageSize),
                
                PagingInfo = new PagingInfo
                {
                    CurrentPage = sketchPage,
                    ItemsPerPage = PageSize,
                    TotalItems = categoryName == null ? dataManager.sketchRepository.AllSketches().Count()
                    : dataManager.sketchRepository.AllSketches()
                    .Where(p => p.categoryName == categoryName).Count()
                },

                CurrentCategory = categoryName
            });
        }
    }
}

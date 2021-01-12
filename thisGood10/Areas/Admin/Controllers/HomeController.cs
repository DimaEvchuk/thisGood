using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thisGood10.Models;

namespace thisGood10.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private DataManager dataManager;
        public HomeController(DataManager _dataManager)
        {
            dataManager = _dataManager;
        }

        public IActionResult Index() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Import()
        {
            //загрузка файла в БД
            string filename = @"F:\thisGood\MyStock.xlsx";


            using (XLWorkbook workBook = new XLWorkbook(filename, XLEventTracking.Disabled))
            {

                foreach (IXLWorksheet worksheet in workBook.Worksheets)
                {
                    Product product = new Product();
                    //sheet.NameSheet = worksheet.Name;


                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                    {
                        product.Id = row.CellCount() - 1;
                        product.NameProduct = row.Cell(1).Value.ToString();
                        product.CountProduct = Convert.ToInt32(row.Cell(2).Value.ToString());
                        product.BuyPrice = Convert.ToDouble(row.Cell(3).Value.ToString());
                        product.SalePrice = Convert.ToDouble(row.Cell(4).Value.ToString());
                        product.Provider = row.Cell(5).Value.ToString();
                    }
                    dataManager.productRepository.SaveProduct(product);
                }
                
            }
            return View();
        }

        
        public async Task<IActionResult> Export()
        {
            //скачивание файла
            // запросы выборка БД
            

            using (XLWorkbook _workBook = new XLWorkbook(XLEventTracking.Disabled))
            {

                //IEnumerable<Category> category = await dataManager.categoryRepository.AllCategories();

                //Создаём листы в Excel и переносим туда данные
                foreach (Category sheetname in await dataManager.categoryRepository.AllCategories())
                {
                    var worksheet = _workBook.Worksheets.Add(sheetname.NameCategory);

                    worksheet.Cell("A1").Value = "Наименование товара";
                    worksheet.Cell("B1").Value = "Кол-во";
                    worksheet.Cell("C1").Value = "Закуп цена";
                    worksheet.Cell("D1").Value = "Цена продажи"; 
                    worksheet.Cell("E1").Value = "Поставщик";  

                    //i - счётчик строки
                    int i = 1;

                    
                    IEnumerable<Product> products = await dataManager.productRepository.GetAllProducts();
                    
                    foreach (var product in products.Where(x => x.CategoryId == sheetname.Id))
                    {
                        worksheet.Cell("A" + ++i).Value = product.NameProduct;
                        worksheet.Cell("B" + i).Value = product.CountProduct;
                        worksheet.Cell("C" + i).Value = product.BuyPrice;
                        worksheet.Cell("D" + i).Value = product.SalePrice;
                        worksheet.Cell("E" + i).Value = product.Provider;
                    }
                }


                //worksheet.Row(1).Style.Font.Bold = true;

                //нумерация строк/столбцов начинается с индекса 1 (а не 0)


                using (var stream = new MemoryStream())
                {
                    //сохраняем книгу
                    _workBook.SaveAs(stream);
                    stream.Flush();
                    //MIMI type for excel file
                    return new FileContentResult(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        //Имя сохраняемого файла
                        FileDownloadName = $"thisGood_{ DateTime.UtcNow.ToShortDateString() }.xlsx"
                    };
                }
            }
        }
    }
}

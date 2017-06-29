using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore2.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string CategoryType)
        {
            var list = new List<Models.Product>();

            using (var wssc = new WebStore2Service.WebStoreServiceClient())
            {
                IEnumerable<Domain.OrdersService.ProductDataContract> products = wssc.GetProducts();

                foreach (var p in products)
                {
                    //  маппинг ProductDataContract на модель для формы
                    Models.Product model = new Models.Product
                    {
                        id = p.id,
                        Name = p.Name,
                        Category = p.Category,
                        Price = p.Price
                    };

                    list.Add(model);
                }

                List<SelectListItem> items = new List<SelectListItem>();

                // читаем категории товаров из базы
                var categories = wssc.GetCategories();

                // заполняем DropDownList для View
                items.Add(new SelectListItem { Text = "Все категории", Value = "All" });

                foreach (var c in categories)
                {
                    items.Add(new SelectListItem { Text = c.Name, Value = c.Name });
                }

                ViewBag.CategoryType = items;

                if (!string.IsNullOrEmpty(CategoryType))
                {
                    if (CategoryType != "All")
                    {
                        // применяем фильтр
                        var FilterList = list.Where(x => x.Category.ToUpper() == CategoryType.ToUpper());
                        list = FilterList.ToList();
                    }
                }
            }

            return View(list);
        }

        public ActionResult Remove(int? id)
        {
            if (id.HasValue)
            {
                using (var wssc = new WebStore2Service.WebStoreServiceClient())
                {
                    wssc.RemoveAt(id.Value);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveAdd(Models.Product model)
        {
            if (ModelState.IsValid)
            {
                //  маппинг модели для формы на ProductDataContract
                Domain.OrdersService.ProductDataContract pdc = new Domain.OrdersService.ProductDataContract
                {
                    Name = model.Name,
                    Category = model.Category,
                    Price = model.Price
                };

                using (var wssc = new WebStore2Service.WebStoreServiceClient())
                {
                    wssc.AddProduct(pdc);
                }

                return RedirectToAction("Index");
            }

            return View("AddProduct", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
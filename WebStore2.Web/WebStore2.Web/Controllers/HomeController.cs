using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore2.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var list = new List<Models.Product>();

            using (var wcc = new WebStore2Service.WebStoreServiceClient())
            {
                IEnumerable<Domain.OrdersService.ProductDataContract> products = wcc.GetProducts();

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
            }

            return View(list);
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
using AppMvc.Net.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public string Index() 
        {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData
            
            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData

            _logger.LogWarning("Thong bao");
            _logger.LogError("Thong bao");
            _logger.LogDebug("Thong bao");
            _logger.LogCritical("Thong bao");
            _logger.LogInformation("Index Action");
            return "Toi la Index";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("hi", "xin chao cac ban");
        }

        public object Anything() => new int[] {1, 2, 3};

        public IActionResult Readme()
        {
            var content = @"
            xin chao cac ban,
            cac ban dang hoc ve APS.NET MVC



            hieunqdev.net
            ";
            return Content(content, "text/plain");
        }

        public IActionResult IphonePrice()
        {
            return Json(
                new {
                    productName = "Iphone X",
                    Price = 1000
                }
            );
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den " + url);
            return LocalRedirect(url); //local ~ host
        }

        public IActionResult Google()
        {
            var url = "https://www.google.com";
            _logger.LogInformation("Chuyen huong den " + url);
            return Redirect(url); //local ~ host
        }

        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
                username = "Khach";
            // View() => Razor Engine, doc .cshtml (template)
            // View(template) - tenplate duong dan tuyet doi den .cshtml
            // View(template, model)
            // return View("/MyView/xinchao1.cshtml", username);
            
            // xinchao2.cshtml -> /View/First/xinchao2.cshtml
            // return View("xinchao2", username);

            // HelloWorld.cshtml -> /View/First/HelloWorld.cshtml
            // /View/Controller/Action.cshtml
            return View((object)username);
        }

        [TempData]
        public string StatusMessage {get; set;}

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                // TempData["StatusMessage"] = "San pham khong co";
                StatusMessage = "San pham khong co";
                return Redirect(Url.Action("Index", "Home"));
            }
            // /View/First/ViewProduct.cshtml
            // /MyView/First/ViewProduct.cshtml

            // (View) truyen du lieu tu Model sang View
            // return View(product);
            
            // (ViewData) truyen du lieu tu Controller sang View
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");
            
            ViewBag.product = product;
            return View("ViewProduct3");

        }

    //      Kiểu trả về                 | Phương thức
    // ------------------------------------------------
    // ContentResult               | Content()
    // EmptyResult                 | new EmptyResult()
    // FileResult                  | File()
    // ForbidResult                | Forbid()
    // JsonResult                  | Json()
    // LocalRedirectResult         | LocalRedirect()
    // RedirectResult              | Redirect()
    // RedirectToActionResult      | RedirectToAction()
    // RedirectToPageResult        | RedirectToRoute()
    // RedirectToRouteResult       | RedirectToPage()
    // PartialViewResult           | PartialView()
    // ViewComponentResult         | ViewComponent()
    // StatusCodeResult            | StatusCode()
    // ViewResult                  | View()
    }
}
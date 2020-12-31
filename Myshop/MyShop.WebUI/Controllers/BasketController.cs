using MyShop.Cores.Contracts;
using MyShop.Cores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketService;
        IOrderService orderService;

        public BasketController(IBasketService BasketService, IOrderService OrderService)
        {
            this.basketService = BasketService;
            this.orderService = OrderService;
        }
        // GET: Basket
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
             if(model.Count < 1)
            {
                TempData["message"] = "No Items in Basket";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public ActionResult AddToBasket(string Id, string qtyVal)
        {
            
            Int32.TryParse(qtyVal, out int qty);
            basketService.AddToBasket(this.HttpContext, Id, qty);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }
        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            var basketItem = basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created";

            // process Payment

            order.OrderStatus = "Payment Processed";
            orderService.CreateOrder(order, basketItem);
            basketService.ClearBasket(this.HttpContext);

            return RedirectToAction("ThankYou", new { OrderId = order.Id });
        }
        public ActionResult ThankYou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }
    }
}
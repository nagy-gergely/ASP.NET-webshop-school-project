using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using musicweb.DataAccessLayer;
using musicweb.Models;
using Microsoft.AspNet.Identity;

namespace musicweb.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private ComicBookDAL comicBookDAL = new ComicBookDAL();

        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<ShoppingCart> shoppingCart = comicBookDAL.ShoppingCart.Where(s => s.UserId == userId).ToList();
            
            return View(shoppingCart);
        }

        public ActionResult Add(int comicBookId)
        {
            ShoppingCart shoppingCartItem = new ShoppingCart();
            shoppingCartItem.UserId = User.Identity.GetUserId();
            shoppingCartItem.ComicBookId = comicBookId;
            shoppingCartItem.Created = DateTime.Now;

            comicBookDAL.ShoppingCart.Add(shoppingCartItem);
            comicBookDAL.SaveChanges();

            return RedirectToAction("Index", "ShoppingCart");
        }

        public ActionResult Delete(int id)
        {
            ShoppingCart shoppingCartToDelete = comicBookDAL.ShoppingCart.Single(s => s.RecordID == id);
            comicBookDAL.ShoppingCart.Remove(shoppingCartToDelete);
            comicBookDAL.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Order()
        {
            string userID = User.Identity.GetUserId();
            List<ShoppingCart> shoppingCarts = comicBookDAL.ShoppingCart.Where(s => s.UserId == userID).ToList();
            foreach (ShoppingCart item in shoppingCarts)
            {
                comicBookDAL.ShoppingCart.Remove(item);
            }
            comicBookDAL.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
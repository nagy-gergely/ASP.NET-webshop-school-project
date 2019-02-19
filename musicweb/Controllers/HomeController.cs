using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using musicweb.BussinessLayer;
using musicweb.DataAccessLayer;
using musicweb.Models;

namespace musicweb.Controllers
{
    /* csak admin jogusáltságú fiokkal lehet új terméket hozzáadni vagy szerkeszteni, törölni.
     * Az admin felhasználónak a userneve: admin, jelszava: Password.1
     * a felhasználói jogosultságokat a Startup.cs-ben hoztam létre.
     * csak bejelentkezve lehet hozzáadni terméket a kosárhoz. 
     * vásárló jogusultságú felhasználot bármikor lehet regisztrálni. */

    public class HomeController : Controller
    {
        private ComicBookDAL comicBookDAL = new ComicBookDAL();
        private ComicBookBL comicBookBL = new ComicBookBL();

        public ActionResult Index()
        {
            return View(comicBookBL.GetComicBook());
        }

        public ActionResult Search()
        {
            string search = Request.Form["searchbox"];
            if (search == "")
            {
                return RedirectToAction("Index");
            }
            else
            {
                List<ComicBook> comicBookList = comicBookBL.GetComicBook();

                List<ComicBook> results = comicBookList.Where(c => c.Title.Contains(search)).ToList();

                return View("Index", results);
            }
        }

        public ActionResult Details(int id)
        {
            ComicBook comicBook = comicBookDAL.ComicBooks.Single(c => c.Id == id);

            return View(comicBook);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult New()
        {
            return View("ComicBookForm");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ComicBook comicBook = comicBookDAL.ComicBooks.Single(c => c.Id == id);

            return View("ComicBookForm", comicBook);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            ComicBook comicBook = comicBookDAL.ComicBooks.Single(c => c.Id == id);
            comicBookDAL.ComicBooks.Remove(comicBook);
            comicBookDAL.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [Authorize(Roles = "Admin")]
        public ActionResult SaveComicBook(ComicBook comicBook)
        {
            if (ModelState.IsValid)
            {
                if (comicBook.Id == null)
                {
                    comicBook.FullImagePath();
                    comicBookDAL.ComicBooks.Add(comicBook);
                }
                else
                {
                    ComicBook comicBookInDB = comicBookDAL.ComicBooks.Single(c => c.Id == comicBook.Id);
                    comicBookInDB.Edit(comicBook);
                }
                comicBookDAL.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("ComicBookForm");
        }

    }
}
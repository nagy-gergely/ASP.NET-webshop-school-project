using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using musicweb.Models;
using musicweb.DataAccessLayer;

namespace musicweb.BussinessLayer
{
    public class ComicBookBL
    {
        public List<ComicBook> GetComicBook()
        {
            ComicBookDAL comicBookDAL = new ComicBookDAL();
            return comicBookDAL.ComicBooks.ToList();
        }
    }
}
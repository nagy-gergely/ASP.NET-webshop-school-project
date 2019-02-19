using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace musicweb.Models
{
    public class ComicBook
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Published { get; set; }
        public string Writer { get; set; }
        public string Penciler { get; set; }
        [Display(Name = "Cover Artist")]
        public string CoverArtist { get; set; }
        public string Description { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public double Price { get; set; }

        public void FullImagePath()
        {
            if (!ImageURL.Contains("~/Content/Images/"))
                ImageURL = String.Format("~/Content/Images/{0}", ImageURL);
        }

        public void Edit(ComicBook comicBook)
        {
            Title = comicBook.Title;
            Published = comicBook.Published.Date;
            Writer = comicBook.Writer;
            Penciler = comicBook.Penciler;
            CoverArtist = comicBook.CoverArtist;
            Description = comicBook.Description;
            Price = comicBook.Price;
            if (comicBook.ImageURL.Contains("~/Content/Images/")) ImageURL = comicBook.ImageURL;
            else String.Format("~/Content/Images/{0}", comicBook.ImageURL);
        }
    }
}
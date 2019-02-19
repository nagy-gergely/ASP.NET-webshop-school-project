using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace musicweb.Models
{
    public class ShoppingCart
    {
        [Key]
        public int RecordID { get; set; }
        [Required]
        public int ComicBookId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
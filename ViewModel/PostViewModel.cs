using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XavierSite.ViewModel
{
    public class PostViewModel
    {
        [Required(ErrorMessage="Please enter title")]
        [MaxLength(50,ErrorMessage="Title length is 50")  ]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter content")]
        public string Content { get; set; }
        public DateTime  CreateDate { get; set; }
    }
}
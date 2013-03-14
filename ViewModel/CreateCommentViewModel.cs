using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XavierSite.ViewModel
{
    public class CreateCommentViewModel
    {
        [Required(ErrorMessage="Please enter your comment")]
        [MaxLength(400,ErrorMessage="The max lengh of comment is 400")]
        public string content { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [MaxLength(50, ErrorMessage = "The max lengh of name is 50")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [MaxLength(50, ErrorMessage = "The max lengh of email address is 50")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public int postId { get; set; }
    }
}
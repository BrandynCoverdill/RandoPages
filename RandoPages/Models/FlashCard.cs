using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RandoPages.Models
{
    public class FlashCard
    {
        [Key]
        public int CardId { get; set; }
        [Required, Display(Name="Question's Category")]
        public string CardType { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}
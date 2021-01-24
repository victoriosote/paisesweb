using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBandera.Models
{
    public class Currency
    {
        [Key]
        public string code { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string symbol { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBandera.Models
{

    public class RegionalBloc
    {
        [Key]
        public string acronym { get; set; }
        [Required]
        public string name { get; set; }
        public List<string> otherAcronyms { get; set; }
        public List<string> otherNames { get; set; }
    }
}
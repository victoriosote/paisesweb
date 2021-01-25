namespace WEBpracticas.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Currency
    {
        [Required]
        public string code { get; set; }
        [Key]
        [Required]
        public string name { get; set; }
        [Required]
        public string symbol { get; set; }
    }

    public class Language
    {
        [Required]
        public string iso639_1 { get; set; }
        [Required]
        public string iso639_2 { get; set; }
        [Key]
        [Required]
        public string name { get; set; }
        [Required]
        public string nativeName { get; set; }
    }

    public class Translations
    {
        [Required]
        public string de { get; set; }
        [Key]
        [Required]
        public string es { get; set; }
        [Required]
        public string fr { get; set; }
        [Required]
        public string ja { get; set; }
        [Required]
        public string it { get; set; }
        [Required]
        public string br { get; set; }
        [Required]
        public string pt { get; set; }
        [Required]
        public string nl { get; set; }
        [Required]
        public string hr { get; set; }
        [Required]
        public string fa { get; set; }
    }

    public class RegionalBloc
    {
        [Required]
        public string acronym { get; set; }
        [Key]
        [Required]
        public string name { get; set; }
        [Required]
        public List<string> otherAcronyms { get; set; }
        [Required]
        public List<string> otherNames { get; set; }
    }
    public class Country
    {
        [Key]
        [Required]
        public string name { get; set; }
        [Required]
        public List<string> topLevelDomain { get; set; }
        [Required]
        public string alpha2Code { get; set; }
        [Required]
        public string alpha3Code { get; set; }
        [Required]
        public List<string> callingCodes { get; set; }
        [Required]
        public string capital { get; set; }
        [Required]
        public List<string> altSpellings { get; set; }
        [Required]
        public string region { get; set; }
        [Required]
        public string subregion { get; set; }
        [Required]
        public int population { get; set; }
        [Required]
        public List<int> latlng { get; set; }
        [Required]
        public string demonym { get; set; }
        [Required]
        public int area { get; set; }
        [Required]
        public double gini { get; set; }
        [Required]
        public List<string> timezones { get; set; }
        [Required]
        public List<string> borders { get; set; }
        [Required]
        public string nativeName { get; set; }
        [Required]
        public string numericCode { get; set; }
        [Required]
        public List<Currency> currencies { get; set; }
        [Required]
        public List<Language> languages { get; set; }
        [Required]
        public Translations translations { get; set; }
        [Required]
        public string flag { get; set; }
        [Required]
        public List<RegionalBloc> regionalBlocs { get; set; }
        [Required]
        public string cioc { get; set; }
    }

}
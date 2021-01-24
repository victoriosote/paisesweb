namespace WebBandera.Models
{
    using System.Data.Entity;
    public class DataContext:DbContext
    {        
        public DataContext():base("DefaultConnection")
        {
                
        }

        public System.Data.Entity.DbSet<WebBandera.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<WebBandera.Models.RegionalBloc> RegionalBlocs { get; set; }

        public System.Data.Entity.DbSet<WebBandera.Models.Language> Languages { get; set; }

        public System.Data.Entity.DbSet<WebBandera.Models.Translations> Translations { get; set; }

        public System.Data.Entity.DbSet<WebBandera.Models.Currency> Currencies { get; set; }
    }
}